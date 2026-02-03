using System.Numerics;

namespace CryptoAlgorithms.Ciphers;

public abstract class LeaCipherBase : ICipher
{
    protected static readonly uint[] Delta = [0xc3efe9db, 0x44626b02, 0x79e27c8a, 0xe887a6fe];
    
    protected int RoundCount;

    public abstract string AlgorithmName { get; }
    public int BlockSize => 16;
    public abstract int KeySize { get; }
    public bool NeedsPadding => true;
    public byte[]? Iv => null;

    public byte[] Encrypt(byte[] dataBlock, byte[] key)
    {
        if (dataBlock.Length != BlockSize) throw new ArgumentException("LEA block size must be 16 bytes.");
        
        uint[,] roundKeys = GenerateRoundKeys(key);
        
        uint[] x = ToUIntArray(dataBlock);
        
        for (int i = 0; i < RoundCount; i++)
        {
            uint temp = x[0];
            
            x[0] = BitOperations.RotateLeft((x[0] ^ roundKeys[i, 0]) + (x[1] ^ roundKeys[i, 1]), 9);
            x[1] = BitOperations.RotateRight((x[1] ^ roundKeys[i, 2]) + (x[2] ^ roundKeys[i, 3]), 5);
            x[2] = BitOperations.RotateRight((x[2] ^ roundKeys[i, 4]) + (x[3] ^ roundKeys[i, 5]), 3);
            x[3] = temp;
        }
        
        return ToByteArray(x);
    }

    public byte[] Decrypt(byte[] dataBlock, byte[] key)
    {
        if (dataBlock.Length != BlockSize) throw new ArgumentException("LEA block size must be 16 bytes.");
        
        uint[,] roundKeys = GenerateRoundKeys(key);
        uint[] x = ToUIntArray(dataBlock);
        
        for (int i = RoundCount - 1; i >= 0; i--)
        {
            uint nextX0 = x[3];
            uint nextX1 = (BitOperations.RotateRight(x[0], 9) - (nextX0 ^ roundKeys[i, 0])) ^ roundKeys[i, 1];
            uint nextX2 = (BitOperations.RotateLeft(x[1], 5) - (nextX1 ^ roundKeys[i, 2])) ^ roundKeys[i, 3];
            uint nextX3 = (BitOperations.RotateLeft(x[2], 3) - (nextX2 ^ roundKeys[i, 4])) ^ roundKeys[i, 5];
            
            x[0] = nextX0;
            x[1] = nextX1;
            x[2] = nextX2;
            x[3] = nextX3;
        }

        return ToByteArray(x);
    }
    
    protected abstract uint[,] GenerateRoundKeys(byte[] key);
    
    private uint[] ToUIntArray(byte[] data)
    {
        uint[] result = new uint[4];
        
        result[0] = BitConverter.ToUInt32(data, 0);
        result[1] = BitConverter.ToUInt32(data, 4);
        result[2] = BitConverter.ToUInt32(data, 8);
        result[3] = BitConverter.ToUInt32(data, 12);
        
        return result;
    }
    
    private byte[] ToByteArray(uint[] data)
    {
        byte[] result = new byte[16];
        
        Array.Copy(BitConverter.GetBytes(data[0]), 0, result, 0, 4);
        Array.Copy(BitConverter.GetBytes(data[1]), 0, result, 4, 4);
        Array.Copy(BitConverter.GetBytes(data[2]), 0, result, 8, 4);
        Array.Copy(BitConverter.GetBytes(data[3]), 0, result, 12, 4);
        
        return result;
    }
}