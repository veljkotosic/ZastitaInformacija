using CryptoAlgorithms.Hashes;

namespace CryptoAlgorithms.Utility;

public static class HashUtility
{
    public static IHash GetHashByName(string hashName)
    {
        return hashName switch
        {
            "SHA-256" => new Sha256(),
            "SHA-512" => new Sha512(),
            _ => throw new NotSupportedException($"{hashName} is not supported.")
        };
    }
    
    public static string ToHexString(this byte[] bytes) => Convert.ToHexString(bytes);
}