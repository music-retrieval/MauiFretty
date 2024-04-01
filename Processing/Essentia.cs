using Fretty.Shared;

namespace Fretty.Processing;

// Represents a connection to an Essentia server
public class Essentia(IServer server)
{
    public IAudioAnalysis Process(string file)
    {
        return server.SendAndAwaitResponse(file);
    }
}
