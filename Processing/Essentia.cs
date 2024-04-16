using Fretty.Shared;
using Fretty.Theory;

namespace Fretty.Processing;

// Represents a connection to an Essentia server
public class Essentia(IServer server, TheoryManager manager)
{
    public IAudioAnalysis Process(string file)
    {
        IAudioAnalysis response = server.SendAndAwaitResponse(file);
        manager.Inform(response);
        
        return response;
    }
}
