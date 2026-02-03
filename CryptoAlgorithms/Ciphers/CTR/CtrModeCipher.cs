namespace CryptoAlgorithms.Ciphers.CTR;

public sealed class CtrModeCipher : ICipher
{
    private readonly ICipher _cipher;
    private readonly byte[] _iv;
    private readonly byte[] _counter;
    
    public CtrModeCipher(ICipher cipher, byte[] iv)
    {
        ArgumentNullException.ThrowIfNull(cipher);
        if (cipher is CtrModeCipher) throw new ArgumentException("CTR mode cannot be nested.");
        if (iv.Length != cipher.BlockSize) throw new ArgumentException($"IV for {cipher.AlgorithmName} must be {cipher.BlockSize} bytes.");
            
        _cipher = cipher;
        _iv = iv;
        _counter = new byte[cipher.BlockSize];
        Array.Copy(iv, _counter, cipher.BlockSize); 
    }

    

    public string AlgorithmName => _cipher.AlgorithmName + "-CTR";
    public int BlockSize => _cipher.BlockSize;
    public int KeySize => _cipher.KeySize;
    public bool NeedsPadding => false;
    public byte[]? Iv => _iv;

    public byte[] Encrypt(byte[] dataBlock, byte[] key)
    {
        byte[] keystream = _cipher.Encrypt(_counter, key);
        byte[] output = new byte[dataBlock.Length];
        
        for (int i = 0; i < dataBlock.Length; i++)
        {
            if (i < keystream.Length) 
            {
                output[i] = (byte)(dataBlock[i] ^ keystream[i]);
            }
        }
        
        IncrementCounter();

        return output;
    }

    public byte[] Decrypt(byte[] dataBlock, byte[] key)
    {
        return Encrypt(dataBlock, key);
    }
    
    private void IncrementCounter()
    {
        for (int i = 0; i < _counter.Length; i++)
        {
            _counter[i]++;
            if (_counter[i] != 0) return; 
        }
    }
}