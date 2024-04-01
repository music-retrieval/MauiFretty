namespace Fretty.Shared;

public interface IServer : IDisposable
{
    IAudioAnalysis SendAndAwaitResponse(string filePath);
}