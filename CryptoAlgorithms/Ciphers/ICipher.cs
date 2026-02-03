using System.Numerics;

namespace CryptoAlgorithms.Ciphers;

public interface ICipher
{
    string AlgorithmName { get; }
    int BlockSize { get; }
    int KeySize { get; }
    bool NeedsPadding { get; }
    byte[]? Iv { get; }
    
    byte[] Encrypt(byte[] dataBlock, byte[] key);
    byte[] Decrypt(byte[] dataBlock, byte[] key);
}