namespace Fretty.Shared;

public class ChordMetric(string value, double strength) : AbstractMetric<string>(value, strength)
{
    public override string ToString()
    {
        return $"Chord: {Value} (strength: {Strength})\n";
    }
}