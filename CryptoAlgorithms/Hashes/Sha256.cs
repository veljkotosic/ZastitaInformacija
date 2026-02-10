using System.Numerics;

namespace CryptoAlgorithms.Hashes;

public sealed class Sha256 : Sha2
{
    private uint[] H = new uint[8];
    private static readonly uint[] K =
    [
        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
    ];
    
    public override string AlgorithmName => "SHA-256";
    
    public Sha256()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        Buffer = new byte[64];
        BufferLen = 0;
        TotalBytesProcessed = 0;
            
        H[0] = 0x6a09e667;
        H[1] = 0xbb67ae85; 
        H[2] = 0x3c6ef372; 
        H[3] = 0xa54ff53a;
        H[4] = 0x510e527f;
        H[5] = 0x9b05688c;
        H[6] = 0x1f83d9ab; 
        H[7] = 0x5be0cd19;
        
        Array.Clear(Buffer, 0, Buffer.Length);
    }
    
    protected override byte[] GetHashAndReset()
    {
        Buffer[BufferLen++] = 0x80;
        if (BufferLen > 56)
        {
            while (BufferLen < 64) Buffer[BufferLen++] = 0;
            ProcessBlock(Buffer);
            BufferLen = 0;
        }
        while (BufferLen < 56) Buffer[BufferLen++] = 0;

        ulong totalBits = TotalBytesProcessed * 8;
        byte[] lenBytes = BitConverter.GetBytes(totalBits);
        
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(lenBytes);
        }
        
        Array.Copy(lenBytes, 0, Buffer, 56, 8);

        ProcessBlock(Buffer);
        
        byte[] hash = new byte[32];
        for (int i = 0; i < H.Length; i++)
        {
            byte[] bytes = BitConverter.GetBytes(H[i]);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            Array.Copy(bytes, 0, hash, i * 4, 4);
        }

        Initialize();
        return hash;
    }

    protected override void ProcessBlock(byte[] chunk)
    {
        uint[] w = new uint[64];

        for (int i = 0; i < 16; i++)
        {
            w[i] =
                ((uint)chunk[i * 4] << 24) |
                ((uint)chunk[i * 4 + 1] << 16) |
                ((uint)chunk[i * 4 + 2] << 8) |
                 (uint)chunk[i * 4 + 3];
        }

        for (int i = 16; i < 64; i++)
        {
            uint s0 = BitOperations.RotateRight(w[i - 15], 7) ^ BitOperations.RotateRight(w[i - 15], 18) ^ (w[i - 15] >> 3);
            uint s1 = BitOperations.RotateRight(w[i - 2], 17) ^ BitOperations.RotateRight(w[i - 2], 19) ^ (w[i - 2] >> 10);
            w[i] = w[i - 16] + s0 + w[i - 7] + s1;
        }

        uint a = H[0], b = H[1], c = H[2], d = H[3], e = H[4], f = H[5], g = H[6], h = H[7];

        for (int i = 0; i < 64; i++)
        {
            uint s1 = BitOperations.RotateRight(e, 6) ^ BitOperations.RotateRight(e, 11) ^ BitOperations.RotateRight(e, 25);
            uint ch = (e & f) ^ (~e & g);
            uint temp1 = h + s1 + ch + K[i] + w[i];
                
            uint s0 = BitOperations.RotateRight(a, 2) ^ BitOperations.RotateRight(a, 13) ^ BitOperations.RotateRight(a, 22);
            uint maj = (a & b) ^ (a & c) ^ (b & c);
            uint temp2 = s0 + maj;

            h = g;
            g = f;
            f = e;
            e = d + temp1;
            d = c;
            c = b;
            b = a;
            a = temp1 + temp2;
        }

        H[0] += a;
        H[1] += b;
        H[2] += c;
        H[3] += d;
        H[4] += e;
        H[5] += f;
        H[6] += g;
        H[7] += h;
    }
}