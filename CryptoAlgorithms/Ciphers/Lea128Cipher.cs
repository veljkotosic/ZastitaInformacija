using System.Buffers.Binary;
using System.Numerics;

namespace CryptoAlgorithms.Ciphers;

public sealed class Lea128Cipher : LeaCipherBase
{
    public Lea128Cipher()
    {
        RoundCount = 24;
    }

    public override string AlgorithmName => "LEA-128";
    public override int KeySize => 16;

    public const int KeyLength = 16;

    protected override uint[,] GenerateRoundKeys(byte[] key)
    {
        if (key.Length != KeySize) throw new ArgumentException("Key must be 16 bytes for LEA-128.");

        uint[] T = new uint[4];
        for (int i = 0; i < 4; i++)
        {
            T[i] = BinaryPrimitives.ReadUInt32LittleEndian(key.AsSpan(i * 4, 4));
        }

        uint[,] roundKeys = new uint[RoundCount, 6];

        for (int i = 0; i < RoundCount; i++)
        {
            T[0] = BitOperations.RotateLeft(T[0] + BitOperations.RotateLeft(Delta[i % 4], i), 1);
            T[1] = BitOperations.RotateLeft(T[1] + BitOperations.RotateLeft(Delta[i % 4], i + 1), 3);
            T[2] = BitOperations.RotateLeft(T[2] + BitOperations.RotateLeft(Delta[i % 4], i + 2), 6);
            T[3] = BitOperations.RotateLeft(T[3] + BitOperations.RotateLeft(Delta[i % 4], i + 3), 11);

            roundKeys[i, 0] = T[0];
            roundKeys[i, 1] = T[1];
            roundKeys[i, 2] = T[2];
            roundKeys[i, 3] = T[1];
            roundKeys[i, 4] = T[3];
            roundKeys[i, 5] = T[1];
        }

        return roundKeys;
    }
}