namespace CryptoApp.Services;

public sealed class Logger : IDisposable, IAsyncDisposable
{
    public event Action<string>? OnLog;
    
    private readonly StreamWriter _swOut;
    private readonly StreamWriter _swLatest;
    
    private readonly Lock _writeLock = new();

    private const string Latest = "latest.log";

    public Logger(string folder = "logs")
    {
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        _swOut = new StreamWriter(Path.Combine(folder, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".log"), false)
        {
            AutoFlush = true
        };
        _swLatest = new StreamWriter(Path.Combine(folder, Latest), false)
        {
            AutoFlush = true
        };
    }
    
    private void Log(string tag, string severity, string message)
    {
        string formatedMessage = $"[{DateTime.Now:HH:mm:ss}][{tag}][{severity}] {message}";

        lock (_writeLock)
        {
            _swOut.WriteLine(formatedMessage);
            _swLatest.WriteLine(formatedMessage);

            OnLog?.Invoke(formatedMessage);
        }
    }
    
    public void LogInfo(string tag, string message) => Log(tag, "INFO", message);
    public void LogWarning(string tag, string message) => Log(tag, "WARNING", message);
    public void LogError(string tag, string message) => Log(tag, "ERROR", message);
    public void LogFatal(string tag, string message) => Log(tag, "FATAL", message);

    public void Dispose()
    {
        _swOut.Dispose();
        _swLatest.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _swOut.DisposeAsync();
        await _swLatest.DisposeAsync();
    }
}