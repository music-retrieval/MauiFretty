using Fretty.Theory;

namespace Fretty.Shared;

public class ChordMetric(string value, double strength)
    : AbstractMetric<Chords.ChordName>(Chords.TryParse(value), strength)
{
    public static ChordMetric Invalid = new("Invalid", 0);

    public override string ToString()
    {
        return $"Chord: {Value} (strength: {Strength})\n";
    }
    
    public bool IsSharpOrFlat()
    {
        return Value.ToString().Contains("Sharp")
               || Value.ToString().Contains("Flat")
               || Value.ToString().Contains('#')
               || Value.ToString().Contains('b');
    }
}