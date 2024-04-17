using Fretty.Shared;

namespace Fretty.Theory;

public class TheoryManager
{
    private IAudioAnalysis? _analysis;

    public List<string> AvailableScales()
    {
        List<Scales.ScaleName> scaleNames = Scales.ScalesContainingChords(_analysis?.ChordProgression());
        List<string> scaleNamesString = scaleNames.Select(s => s.ToString()).ToList();
        
        return scaleNamesString;
    }
    
    private readonly List<Action<List<string>>> _scaleListeners = [];
    
    public void Inform(IAudioAnalysis audioAnalysis)
    {
        _analysis = audioAnalysis;
        
        foreach (Action<List<string>> listener in _scaleListeners)
        {
            listener(AvailableScales());
        }
    }
    
    public void RegisterScaleListener(Action<List<string>> listener)
    {
        _scaleListeners.Add(listener);
    }
}
