using CryptoAlgorithms.Ciphers;
using CryptoAlgorithms.Hashes;
using CryptoFileSystem;

namespace CryptoApp.Services;

public static class ManualService
{
    private const string ManualLogTag = "MAN";

    public static void Encrypt(string inputFile, string outputDirectory, string key, ICipher cipher, IHash hasher, Logger logger)
    {
        byte[] hashedKey = new Sha256().ComputeHash(key);
        string fileName = Path.GetFileName(inputFile);

        try
        {
            logger.LogInfo(ManualLogTag, $"Encrypting {fileName} using {cipher.AlgorithmName} and {hasher.AlgorithmName}.");

            FileProcessor.EncryptFile(inputFile, Path.Combine(outputDirectory, fileName + ".enc"),
                cipher, hasher, hashedKey);

            logger.LogInfo(ManualLogTag, $"File {fileName} encrypted successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ManualLogTag, $"Failed to encrypt {fileName}.");
            logger.LogError(ManualLogTag, ex.Message);
        }
    }

    public static void Decrypt(string inputFile, string outputDirectory, string key, Logger logger)
    {
        byte[] hashedKey = new Sha256().ComputeHash(key);

        try
        {
            logger.LogInfo(ManualLogTag, $"Decrypting {inputFile}.");

            FileProcessor.DecryptFile(inputFile, outputDirectory, hashedKey);

            logger.LogInfo(ManualLogTag, $"File {inputFile} decrypted successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ManualLogTag, $"Failed to decrypt {inputFile}.");
            logger.LogError(ManualLogTag, ex.Message);
        }
    }
}