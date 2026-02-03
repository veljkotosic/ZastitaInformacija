using CryptoAlgorithms.Ciphers;
using CryptoAlgorithms.Hashes;
using CryptoFileSystem;

namespace CryptoApp.Services;

public sealed class FolderWatcherService(
    string inputFolder,
    string outputFolder,
    byte[] key,
    ICipher cipher,
    IHash hasher,
    Logger logger)
{
    private FileSystemWatcher? _fileSystemWatcher;

    private const string LogTag = "FSW";
    private const string WorkerLogTag = "FSW_WORKER";

    public void Start()
    {
        if (inputFolder.Equals(outputFolder, StringComparison.OrdinalIgnoreCase))
        {
            logger.LogError(LogTag, "Service could not be started.");
            logger.LogError(LogTag, "Input and output folders cannot be the same.");
            return;
        }
        
        if (!Directory.Exists(inputFolder)) Directory.CreateDirectory(inputFolder);
        if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

        _fileSystemWatcher = new(inputFolder);
        _fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

        _fileSystemWatcher.Filter = "*.*";
        _fileSystemWatcher.Created += OnFileCreated;
        _fileSystemWatcher.EnableRaisingEvents = true;

        logger.LogInfo(LogTag, $"Service started and watching on {inputFolder}.");
        logger.LogInfo(LogTag, $"Using {cipher.AlgorithmName} and {hasher.AlgorithmName} for encryption.");
    }

    private void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        logger.LogInfo(LogTag, $"File detected: {e.Name}");

        ThreadPool.QueueUserWorkItem(_ => ProcessFile(e.FullPath, e.Name));
    }

    private void ProcessFile(string fullPath, string? fileName)
    {
        try
        {
            if (!WaitForFile(fullPath))
            {
                logger.LogError(WorkerLogTag, $"File {fileName} is locked or inaccessible.");
                return;
            }

            string outputFile = Path.Combine(outputFolder, fileName + ".enc");
            
            logger.LogInfo(WorkerLogTag, $"Encrypting {fileName}...");
            
            FileProcessor.EncryptFile(fullPath, outputFile, cipher, hasher, key);
            
            logger.LogInfo(WorkerLogTag, $"Successfully encrypted {fileName} to {outputFile}");
        }
        catch (Exception ex)
        {
            logger.LogError(WorkerLogTag, $"Failed to encrypt {fileName}");
            logger.LogError(WorkerLogTag, ex.Message);
        }
    }

    private bool WaitForFile(string fullPath)
    {
        int numRetries = 10;
        int delayMs = 500;

        for (int i = 0; i < numRetries; i++)
        {
            try
            {
                using FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.None);
                return true;
            }
            catch (IOException)
            {
                Thread.Sleep(delayMs);
            }
        }

        return false;
    }

    public void Stop()
    {
        if (_fileSystemWatcher != null)
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Dispose();
            _fileSystemWatcher = null;
        }

        logger.LogInfo(LogTag, "Service Stopped.");
    }
}