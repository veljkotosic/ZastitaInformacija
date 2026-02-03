using CryptoAlgorithms.Ciphers;
using CryptoAlgorithms.Ciphers.CTR;

namespace CryptoAlgorithms.Utility;

public static class CiphersUtility
{
    public static ICipher GetCipherByName(string cipherName, byte[]? iv)
    {
        return cipherName switch
        {
            "TEA" => new TeaCipher(),
            "LEA-128" => new Lea128Cipher(),
            "LEA-192" => new Lea192Cipher(),
            "LEA-256" => new Lea256Cipher(),
            "TEA-CTR" => new CtrModeCipher(new TeaCipher(), iv!),
            "LEA-128-CTR" => new CtrModeCipher(new Lea128Cipher(), iv!),
            "LEA-192-CTR" => new CtrModeCipher(new Lea192Cipher(), iv!),
            "LEA-256-CTR" => new CtrModeCipher(new Lea256Cipher(), iv!),
            _ => throw new NotSupportedException($"{cipherName} is not supported.")
        };
    }
}