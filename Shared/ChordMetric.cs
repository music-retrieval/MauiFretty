using Fretty.Theory;

namespace Fretty.Shared;

public class ChordMetric: AbstractMetric<Chords.ChordName>
{
    public static ChordMetric Invalid = new ChordMetric("C", 0);
    
    public ChordMetric(string values, double strength): base(TryParse(values), strength)
    {
    }
    
    private static Chords.ChordName TryParse(string essentiaChord)
    {
        // Convert the essentiaChord string to the format of the ChordName enum values
        string chordNameString;
        if (essentiaChord.EndsWith("m"))
        {
            chordNameString = essentiaChord.TrimEnd('m') + "Minor";
        }
        else
        {
            chordNameString = essentiaChord + "Major";
        }

        // Parse the chordNameString to a ChordName enum value
        return Enum.TryParse<Chords.ChordName>(chordNameString, out Chords.ChordName chordName)
            ? chordName
            : Chords.ChordName.Invalid;
    }
    
    public override string ToString()
    {
        return $"Chord: {Value} (strength: {Strength})\n";
    }
}