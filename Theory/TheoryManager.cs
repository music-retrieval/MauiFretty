using Fretty.Shared;

namespace Fretty.Theory;

public class TheoryManager
{
    private IAudioAnalysis? _analysis;

    public List<string> AvailableScales()
    {
        return _analysis?.Key().Scales() ?? new List<string>();
    }
    
    public void Inform(IAudioAnalysis audioAnalysis)
    {
        _analysis = audioAnalysis;
    }
}
