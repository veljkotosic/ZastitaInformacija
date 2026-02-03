namespace CryptoFileSystem;

public class FileHeader
{
    public string OriginalName { get; init; }     
    public long OriginalSize { get; init; }       
    public DateTime CreatedDate { get; init; }    
    public string CipherAlgorithm { get; init; }        
    public string HashAlgorithm { get; init; }    
    public string Hash { get; init; }
    public string IV { get; init; }
}