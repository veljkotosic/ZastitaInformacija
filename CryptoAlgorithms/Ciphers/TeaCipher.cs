namespace CryptoAlgorithms.Ciphers;

public class TeaCipher : ICipher
{
    private const uint Delta = 0x9E3779B9;

    public string AlgorithmName => "TEA";
    public int BlockSize => 8;
    public int KeySize => 16;
    public bool NeedsPadding => true;
    public byte[]? Iv => null;

    public const int KeyLength = 16;

    public byte[] Encrypt(byte[] dataBlock, byte[] key)
    {
        if (dataBlock.Length != BlockSize) throw new ArgumentException("TEA block size must be 8 bytes.");
        if (key.Length != KeySize) throw new ArgumentException("TEA key size must be 16 bytes.");
        
        uint v0 = BitConverter.ToUInt32(dataBlock, 0);
        uint v1 = BitConverter.ToUInt32(dataBlock, 4);
        
        uint sum = 0;
        
        uint k0 = BitConverter.ToUInt32(key, 0);
        uint k1 = BitConverter.ToUInt32(key, 4);
        uint k2 = BitConverter.ToUInt32(key, 8);
        uint k3 = BitConverter.ToUInt32(key, 12);
        
        for (int i = 0; i < 32; i++) 
        {
            sum += Delta;
            v0 += ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
            v1 += ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
        }
        
        byte[] result = new byte[8];
        
        Array.Copy(BitConverter.GetBytes(v0), 0, result, 0, 4);
        Array.Copy(BitConverter.GetBytes(v1), 0, result, 4, 4);
        
        return result;
    }

    public byte[] Decrypt(byte[] dataBlock, byte[] key)
    {
        if (dataBlock.Length != BlockSize) throw new ArgumentException("Data block must be 8 bytes.");
        if (key.Length != KeySize) throw new ArgumentException("Key must be 16 bytes.");
        
        uint v0 = BitConverter.ToUInt32(dataBlock, 0);
        uint v1 = BitConverter.ToUInt32(dataBlock, 4);

        uint k0 = BitConverter.ToUInt32(key, 0);
        uint k1 = BitConverter.ToUInt32(key, 4);
        uint k2 = BitConverter.ToUInt32(key, 8);
        uint k3 = BitConverter.ToUInt32(key, 12);
        
        uint sum = 0xC6EF3720;
        
        for (int i = 0; i < 32; i++)
        {
            v1 -= ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
            v0 -= ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
            sum -= Delta;
        }
        
        byte[] result = new byte[8];
        
        Array.Copy(BitConverter.GetBytes(v0), 0, result, 0, 4);
        Array.Copy(BitConverter.GetBytes(v1), 0, result, 4, 4);
        
        return result;
    }
}