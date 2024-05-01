using Fretty.Theory;

namespace Fretty.Shared;

public interface IAudioAnalysis
{
    IEnumerable<ChordMetric> Chords();

    KeyMetric Key();
    
    IEnumerable<Chords.ChordName> ChordProgression();
}