using System.Buffers.Binary;
using System.Numerics;

namespace CryptoAlgorithms.Ciphers;

public sealed class Lea192Cipher : LeaCipherBase
{
    public Lea192Cipher()
    {
        RoundCount = 28;
    }

    public override string AlgorithmName => "LEA-192";
    public override int KeySize => 24;

    public const int KeyLength = 24;

    protected override uint[,] GenerateRoundKeys(byte[] key)
    {
        if (key.Length != KeySize) throw new ArgumentException("Key must be 24 bytes for LEA-192.");

        uint[] T = new uint[6];
        for (int i = 0; i < 6; i++)
        {
            T[i] = BinaryPrimitives.ReadUInt32LittleEndian(key.AsSpan(i * 4, 4));
        }

        uint[,] roundKeys = new uint[RoundCount, 6];

        for (int i = 0; i < RoundCount; i++)
        {
            var d = Delta[i % 6];

            T[0] = BitOperations.RotateLeft(T[0] + BitOperations.RotateLeft(d, i), 1);
            T[1] = BitOperations.RotateLeft(T[1] + BitOperations.RotateLeft(d, i + 1), 3);
            T[2] = BitOperations.RotateLeft(T[2] + BitOperations.RotateLeft(d, i + 2), 6);
            T[3] = BitOperations.RotateLeft(T[3] + BitOperations.RotateLeft(d, i + 3), 11);
            T[4] = BitOperations.RotateLeft(T[4] + BitOperations.RotateLeft(d, i + 4), 13);
            T[5] = BitOperations.RotateLeft(T[5] + BitOperations.RotateLeft(d, i + 5), 17);

            roundKeys[i, 0] = T[0];
            roundKeys[i, 1] = T[1];
            roundKeys[i, 2] = T[2];
            roundKeys[i, 3] = T[3];
            roundKeys[i, 4] = T[4];
            roundKeys[i, 5] = T[5];
        }

        return roundKeys;
    }
}