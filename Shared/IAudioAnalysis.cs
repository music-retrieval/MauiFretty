namespace Fretty.Shared;

public interface IAudioAnalysis
{
    IEnumerable<ChordMetric> Chords();

    KeyMetric Key();
}