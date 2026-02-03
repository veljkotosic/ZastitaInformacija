using System.Text;
using System.Text.Json;
using CryptoAlgorithms.Ciphers;
using CryptoAlgorithms.Hashes;
using CryptoAlgorithms.Utility;

namespace CryptoFileSystem;

public static class FileProcessor
{
    public static void EncryptFile(string inputFile, string outputFile, ICipher cipher, IHash hasher, byte[] key)
    {
        key = key.Take(cipher.KeySize).ToArray();
        
        string fileHash;
        using (var fsHash = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
        {
            fileHash = hasher.ComputeHash(fsHash).ToHexString();
        }

        FileInfo inputFileInfo = new FileInfo(inputFile);
        
        FileHeader fileHeader = new FileHeader()
        {
            OriginalName = inputFileInfo.Name,
            OriginalSize = inputFileInfo.Length,
            CreatedDate = DateTime.Now,
            CipherAlgorithm = cipher.AlgorithmName,
            HashAlgorithm = hasher.AlgorithmName,
            Hash = fileHash, 
            IV = cipher.Iv != null ? Convert.ToBase64String(cipher.Iv!) : ""
        };
        
        string jsonHeader = JsonSerializer.Serialize(fileHeader);
        byte[] headerBytes = Encoding.UTF8.GetBytes(jsonHeader);
        byte[] headerLengthBytes = BitConverter.GetBytes(headerBytes.Length);
        
        using (var fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
        using (var fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
        {
            fsOut.Write(headerLengthBytes, 0, headerLengthBytes.Length);
            fsOut.Write(headerBytes, 0, headerBytes.Length);
            
            byte[] buffer = new byte[cipher.BlockSize];
            
            int bytesRead;
            
            while ((bytesRead = fsIn.Read(buffer, 0, cipher.BlockSize)) > 0)
            {
                byte[] blockToEncrypt = buffer;

                if (cipher.NeedsPadding && bytesRead < cipher.BlockSize)
                {
                    blockToEncrypt = new byte[cipher.BlockSize];
                    Array.Copy(buffer, blockToEncrypt, bytesRead);
                }
                else if (!cipher.NeedsPadding && bytesRead < cipher.BlockSize)
                {
                    blockToEncrypt = new byte[bytesRead];
                    Array.Copy(buffer, blockToEncrypt, bytesRead);
                }

                byte[] encryptedBlock = cipher.Encrypt(blockToEncrypt, key);
                    
                fsOut.Write(encryptedBlock, 0, encryptedBlock.Length);
            }
        }
    }

    public static void DecryptFile(string inputFile, string outputDirectory, byte[] key)
    {
        using var fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
        byte[] lenBytes = new byte[4];
            
        if (fsIn.Read(lenBytes, 0, 4) != 4)
        {
            throw new FileProcessorException("Invalid file. Failed to read header length.");
        }
            
        int headerLen = BitConverter.ToInt32(lenBytes, 0);
            
        byte[] headerBytes = new byte[headerLen];

        if (fsIn.Read(headerBytes, 0, headerLen) != headerLen)
        {
            throw new FileProcessorException("Invalid header. Header length does not match actual header length.");
        }
            
        string jsonHeader = Encoding.UTF8.GetString(headerBytes);
        FileHeader? header = JsonSerializer.Deserialize<FileHeader>(jsonHeader);

        if (header == null)
        {
            throw new FileProcessorException("Corrupted header. Failed to deserialize header.");
        }
            
        ICipher cipher;
        try
        {
            cipher = CiphersUtility.GetCipherByName(header.CipherAlgorithm, header.IV != "" ? Convert.FromBase64String(header.IV) : null);
        }
        catch (NotSupportedException e)
        {
            throw new FileProcessorException($"Invalid cipher algorithm. {e.Message}");
        }

        IHash hasher;
        try
        {
            hasher = HashUtility.GetHashByName(header.HashAlgorithm);
        }
        catch (NotSupportedException e)
        {
            throw new FileProcessorException($"Invalid hash algorithm. {e.Message}");
        }

        key = key.Take(cipher.KeySize).ToArray();
            
        if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
            
        string outputPath = Path.Combine(outputDirectory, header.OriginalName);

        using (var fsOut = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[cipher.BlockSize];
            int bytesRead;

            while ((bytesRead = fsIn.Read(buffer, 0, cipher.BlockSize)) > 0)
            {
                byte[] decryptedBlock = cipher.Decrypt(buffer, key);
                if (cipher.NeedsPadding)
                {
                    if (fsIn.Position == fsIn.Length)
                    {
                        int validBytes = cipher.BlockSize;
                        while (validBytes > 0 && decryptedBlock[validBytes - 1] == 0) validBytes--;
                        fsOut.Write(decryptedBlock, 0, validBytes);
                    }
                    else
                    {
                        fsOut.Write(decryptedBlock, 0, decryptedBlock.Length);
                    }
                }
                else
                {
                    fsOut.Write(decryptedBlock, 0, bytesRead);
                }
            }
        }

        using (FileStream fsHash = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
        {
            string fileHash = hasher.ComputeHash(fsHash).ToHexString();
            
            if (fileHash != header.Hash)
            {
                throw new FileProcessorException("Corrupted file. Hash does not match.");
            }
        }
    }
}