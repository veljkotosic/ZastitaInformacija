namespace CryptoAlgorithms.Hashes;

public abstract class Sha2 : IHash
{
    private const int ChunkSize = 4096;

    protected byte[] Buffer;
    protected int BufferLen;
    protected ulong TotalBytesProcessed;

    protected abstract void Initialize();
    protected abstract void ProcessBlock(byte[] data);
    protected abstract byte[] GetHashAndReset();

    public abstract string AlgorithmName { get; }

    public byte[] ComputeHash(byte[] data)
    {
        Initialize();
        ExtractBlocks(data, 0, data.Length);
        return GetHashAndReset();
    }

    public byte[] ComputeHash(string data)
    {
        if (data is null) throw new ArgumentNullException(nameof(data));
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        return ComputeHash(bytes);
    }

    public byte[] ComputeHash(Stream stream)
    {
        Initialize();
        byte[] chunk = new byte[ChunkSize]; 
        int bytesRead;

        while ((bytesRead = stream.Read(chunk, 0, chunk.Length)) > 0)
        {
            ExtractBlocks(chunk, 0, bytesRead);
        }

        return GetHashAndReset();
    }

    private void ExtractBlocks(byte[] input, int offset, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Buffer[BufferLen++] = input[offset + i];
            TotalBytesProcessed++;

            if (BufferLen == Buffer.Length)
            {
                ProcessBlock(Buffer);
                BufferLen = 0;
            }
        }
    }
}