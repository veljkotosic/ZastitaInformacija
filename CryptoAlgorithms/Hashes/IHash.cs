namespace CryptoAlgorithms.Hashes;

public interface IHash
{
    string AlgorithmName { get; }
    byte[] ComputeHash(byte[] data);
    byte[] ComputeHash(string data);
    byte[] ComputeHash(Stream stream);
}