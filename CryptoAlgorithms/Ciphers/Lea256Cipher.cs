using System.Numerics;

namespace CryptoAlgorithms.Ciphers;

public sealed class Lea256Cipher : LeaCipherBase
{
    public Lea256Cipher()
    {
        RoundCount = 32;
    }

    public override string AlgorithmName => "LEA-256";
    public override int KeySize => 32;
    
    public const int KeyLength = 32;

    protected override uint[,] GenerateRoundKeys(byte[] key)
    {
        if (key.Length != KeySize) throw new ArgumentException("Key must be 32 bytes for LEA-256.");

        uint[] T = new uint[8];
        for (int i = 0; i < 8; i++)
        {
            T[i] = BitConverter.ToUInt32(key, i * 4);
        }

        uint[,] roundKeys = new uint[RoundCount, 6];
        
        for (int i = 0; i < RoundCount; i++)
        {
            int baseIndex = 6 * i;
            
            int idx0 = (baseIndex + 0) % 8;
            T[idx0] = BitOperations.RotateLeft(T[idx0] + BitOperations.RotateLeft(Delta[i % 4], i), 1);
            roundKeys[i, 0] = T[idx0];
            
            int idx1 = (baseIndex + 1) % 8;
            T[idx1] = BitOperations.RotateLeft(T[idx1] + BitOperations.RotateLeft(Delta[i % 4], i + 1), 3);
            roundKeys[i, 1] = T[idx1];
            
            int idx2 = (baseIndex + 2) % 8;
            T[idx2] = BitOperations.RotateLeft(T[idx2] + BitOperations.RotateLeft(Delta[i % 4], i + 2), 6);
            roundKeys[i, 2] = T[idx2];
            
            int idx3 = (baseIndex + 3) % 8;
            T[idx3] = BitOperations.RotateLeft(T[idx3] + BitOperations.RotateLeft(Delta[i % 4], i + 3), 11);
            roundKeys[i, 3] = T[idx3];
            
            int idx4 = (baseIndex + 4) % 8;
            T[idx4] = BitOperations.RotateLeft(T[idx4] + BitOperations.RotateLeft(Delta[i % 4], i + 4), 13);
            roundKeys[i, 4] = T[idx4];
            
            int idx5 = (baseIndex + 5) % 8;
            T[idx5] = BitOperations.RotateLeft(T[idx5] + BitOperations.RotateLeft(Delta[i % 4], i + 5), 17);
            roundKeys[i, 5] = T[idx5];
        }
        
        return roundKeys;
    }
}