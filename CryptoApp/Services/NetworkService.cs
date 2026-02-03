using System.Net;
using System.Net.Sockets;
using CryptoAlgorithms.Ciphers;
using CryptoAlgorithms.Hashes;
using CryptoFileSystem;

namespace CryptoApp.Services;

public sealed class NetworkService(string outputDirectory, byte[] key, Logger logger)
{
    private TcpListener? _listener;
    private CancellationTokenSource? _cts;

    private const string LogTag = "NET";
    private const string ReceiverLogTag = "NET_RCV";
    private const string SenderLogTag = "NET_SND";

    public void Start(int port)
    {
        _cts = new CancellationTokenSource();
        _listener = new TcpListener(IPAddress.Any, port);

        try
        {
            _listener.Start();
            logger.LogInfo(LogTag, $"Network service started on port {port}.");
            Task.Run(() => ListenAsync(_cts.Token), _cts.Token);
        }
        catch (Exception ex)
        {
            logger.LogError(LogTag, $"Failed to start network service: {ex.Message}");
        }
    }

    private async Task ListenAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                TcpClient client = await _listener!.AcceptTcpClientAsync(token);
                logger.LogInfo(ReceiverLogTag, $"Connection accepted from {client.Client.RemoteEndPoint}");
                _ = HandleClientAsync(client, token);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    logger.LogError(ReceiverLogTag, $"Error accepting connection: {ex.Message}");
                }
            }
        }
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken token)
    {
        using (client)
        await using (NetworkStream stream = client.GetStream())
        {
            try
            {
                // Protocol: 
                // 1. Filename length (int, 4 bytes)
                // 2. Filename (string)
                // 3. File content size (long, 8 bytes)
                // 4. File content

                byte[] intBuffer = new byte[4];
                if (await ReadExactlyAsync(stream, intBuffer, 4, token) != 4) return;
                int fileNameLen = BitConverter.ToInt32(intBuffer, 0);

                byte[] fileNameBuffer = new byte[fileNameLen];
                if (await ReadExactlyAsync(stream, fileNameBuffer, fileNameLen, token) != fileNameLen) return;
                string fileName = System.Text.Encoding.UTF8.GetString(fileNameBuffer);

                byte[] longBuffer = new byte[8];
                if (await ReadExactlyAsync(stream, longBuffer, 8, token) != 8) return;
                long fileSize = BitConverter.ToInt64(longBuffer, 0);

                logger.LogInfo(ReceiverLogTag, $"Receiving file: {fileName} ({fileSize} bytes)");

                string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".tmp");
                await using (FileStream fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8192];
                    long totalRead = 0;
                    while (totalRead < fileSize)
                    {
                        int toRead = (int)Math.Min(buffer.Length, fileSize - totalRead);
                        int read = await stream.ReadAsync(buffer, 0, toRead, token);
                        if (read == 0) break;
                        await fs.WriteAsync(buffer, 0, read, token);
                        totalRead += read;
                    }
                }

                logger.LogInfo(ReceiverLogTag, $"File {fileName} received. Queuing for decryption.");

                ThreadPool.QueueUserWorkItem(_ => DecryptReceivedFile(tempPath, fileName));
            }
            catch (Exception ex)
            {
                logger.LogError(ReceiverLogTag, $"Error receiving file: {ex.Message}");
            }
        }
    }

    private void DecryptReceivedFile(string tempPath, string originalFileName)
    {
        try
        {
            logger.LogInfo(ReceiverLogTag, $"Decrypting {originalFileName}...");
            FileProcessor.DecryptFile(tempPath, outputDirectory, key);
            logger.LogInfo(ReceiverLogTag, $"Successfully decrypted {originalFileName} to {outputDirectory}");
        }
        catch (Exception ex)
        {
            logger.LogError(ReceiverLogTag, $"Failed to decrypt received file {originalFileName}: {ex.Message}");
        }
        finally
        {
            if (File.Exists(tempPath)) File.Delete(tempPath);
        }
    }

    private async Task<int> ReadExactlyAsync(Stream stream, byte[] buffer, int count, CancellationToken token)
    {
        int totalRead = 0;
        while (totalRead < count)
        {
            int read = await stream.ReadAsync(buffer, totalRead, count - totalRead, token);
            if (read == 0) return totalRead;
            totalRead += read;
        }
        return totalRead;
    }

    public void Stop()
    {
        _cts?.Cancel();
        _listener?.Stop();
        logger.LogInfo(LogTag, "Network service stopped.");
    }

    public static async Task SendFileAsync(string filePath, string ipAddress, int port, ICipher cipher, IHash hasher, byte[] key, Logger logger)
    {
        string? tempEncryptedPath = null;
        try
        {
            logger.LogInfo(SenderLogTag, $"Preparing to send file: {Path.GetFileName(filePath)}");
            
            tempEncryptedPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".enc");
            FileProcessor.EncryptFile(filePath, tempEncryptedPath, cipher, hasher, key);
            
            using TcpClient client = new TcpClient();
            await client.ConnectAsync(ipAddress, port);
            await using NetworkStream stream = client.GetStream();

            string originalFileName = Path.GetFileName(filePath);
            string encryptedFileName = originalFileName + ".enc";
            byte[] fileNameBytes = System.Text.Encoding.UTF8.GetBytes(encryptedFileName);
            byte[] fileNameLenBytes = BitConverter.GetBytes(fileNameBytes.Length);
            
            FileInfo fi = new FileInfo(tempEncryptedPath);
            byte[] fileSizeBytes = BitConverter.GetBytes(fi.Length);

            logger.LogInfo(SenderLogTag, $"Sending encrypted file {encryptedFileName} ({fi.Length} bytes) to {ipAddress}:{port}...");

            await stream.WriteAsync(fileNameLenBytes, 0, 4);
            await stream.WriteAsync(fileNameBytes, 0, fileNameBytes.Length);
            await stream.WriteAsync(fileSizeBytes, 0, 8);

            await using (FileStream fs = new FileStream(tempEncryptedPath, FileMode.Open, FileAccess.Read))
            {
                await fs.CopyToAsync(stream);
            }

            logger.LogInfo(SenderLogTag, $"File {encryptedFileName} sent successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(SenderLogTag, $"Failed to send file: {ex.Message}");
            throw;
        }
        finally
        {
            if (tempEncryptedPath != null && File.Exists(tempEncryptedPath))
            {
                try
                {
                    File.Delete(tempEncryptedPath);
                }
                catch
                {
                     
                }
            }
        }
    }
}