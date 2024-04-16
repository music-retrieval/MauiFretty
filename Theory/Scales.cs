namespace Fretty.Theory;

// Class holding all scales and scale-related functions
public static class Scales
{

    // Enum of all scale names
    public enum ScaleName
    {
        //A Scales
        AMajor,
        AMinor,
        APentatonic,
        ABlues,
        AIonian,

        //A# Scales
        ASharpMajor,
        ASharpMinor,
        ASharpPentatonic,
        ASharpBlues,
        ASharpIonian,

        //B Scales
        BMajor,
        BMinor,
        BPentatonic,
        BBlues,
        BIonian,

        //C Scales
        CMajor,
        CMinor,
        CPentatonic,
        CBlues,
        CIonian,

        //C# Scales
        CSharpMajor,
        CSharpMinor,
        CSharpPentatonic,
        CSharpBlues,
        CSharpIonian,

        //D Scales
        DMajor,
        DMinor,
        DPentatonic,
        DBlues,
        DIonian,

        //D# Scales
        DSharpMajor,
        DSharpMinor,
        DSharpPentatonic,
        DSharpBlues,
        DSharpIonian,

        //E Scales
        EMajor,
        EMinor,
        EPentatonic,
        EBlues,
        EIonian,

        //F Scales
        FMajor,
        FMinor,
        FPentatonic,
        FBlues,
        FIonian,

        //F# Scales
        FSharpMajor,
        FSharpMinor,
        FSharpPentatonic,
        FSharpBlues,
        FSharpIonian,

        //G Scales
        GMajor,
        GMinor,
        GPentatonic,
        GBlues,
        GIonian,

        //G# Scales
        GSharpMajor,
        GSharpMinor,
        GSharpPentatonic,
        GSharpBlues,
        GSharpIonian
    }


    // Dictionary of all scales, with the scale name as the key and the scale as the value
    // Where the scale is represented as a dictionary of notes in the scale, with the note as the key and the position in the scale as the value
    // With the root note as 1, the second note as 2, etc.
    private static readonly Dictionary<ScaleName, Dictionary<Note, string>> AllScales = new Dictionary<ScaleName, Dictionary<Note, string>>    
    {
        {
            ScaleName.AMajor,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("B"), "2" },
                { new Note("C#"), "3" },
                { new Note("D"), "4" },
                { new Note("E"), "5" },
                { new Note("F#"), "6" },
                { new Note("G#"), "7" }
            }
        },
        {
            ScaleName.ASharpMajor,
            new Dictionary<Note, string>
            {
                { new Note("A#"), "1" },
                { new Note("C"), "2" },
                { new Note("D"), "3" },
                { new Note("D#"), "4" },
                { new Note("F"), "5" },
                { new Note("G"), "6" },
                { new Note("A"), "7" }
            }
        },
        {
            ScaleName.BMajor,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("C#"), "2" },
                { new Note("D#"), "3" },
                { new Note("E"), "4" },
                { new Note("F#"), "5" },
                { new Note("G#"), "6" },
                { new Note("A#"), "7" }
            }
        },
        {
            ScaleName.CMajor,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D"), "2" },
                { new Note("E"), "3" },
                { new Note("F"), "4" },
                { new Note("G"), "5" },
                { new Note("A"), "6" },
                { new Note("B"), "7" }
            }
        },
        {
            ScaleName.CMinor,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D"), "2" },
                { new Note("D#"), "b3" },
                { new Note("F"), "4" },
                { new Note("G"), "5" },
                { new Note("G#"), "b6" },
                { new Note("A#"), "b7" }
            }
        },
        {
            ScaleName.CSharpMajor,
            new Dictionary<Note, String>
            {
                { new Note("C#"), "1" },
                { new Note("D#"), "2" },
                { new Note("F"), "3" },
                { new Note("F#"), "4" },
                { new Note("G#"), "5" },
                { new Note("A#"), "6" },
                { new Note("C"), "7" }
            }
        },
        {
            ScaleName.DMajor,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("E"), "2" },
                { new Note("F#"), "3" },
                { new Note("G"), "4" },
                { new Note("A"), "5" },
                { new Note("B"), "6" },
                { new Note("C#"), "7" }
            }
        },
        {
            ScaleName.DSharpMajor,
            new Dictionary<Note, string>
            {
                { new Note("D#"), "1" },
                { new Note("F"), "2" },
                { new Note("G"), "3" },
                { new Note("G#"), "4" },
                { new Note("A#"), "5" },
                { new Note("C"), "6" },
                { new Note("D"), "7" }
            }
        },
        {
            ScaleName.EMajor,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("F#"), "2" },
                { new Note("G#"), "3" },
                { new Note("A"), "4" },
                { new Note("B"), "5" },
                { new Note("C#"), "6" },
                { new Note("D#"), "7" }
             }
        },
        {
            ScaleName.FMajor,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("G"), "2" },
                { new Note("A"), "3" },
                { new Note("A#"), "4" },
                { new Note("C"), "5" },
                { new Note("D"), "6" },
                { new Note("E"), "7" }
            }
        },
        {
            ScaleName.FSharpMajor,
            new Dictionary<Note, string>
            {
                { new Note("F#"), "1" },
                { new Note("G#"), "2" },
                { new Note("A#"), "3" },
                { new Note("B"), "4" },
                { new Note("C#"), "5" },
                { new Note("D#"), "6" },
                { new Note("F"), "7" }
            }
        },
        {
            ScaleName.GMajor,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("A"), "2" },
                { new Note("B"), "3" },
                { new Note("C"), "4" },
                { new Note("D"), "5" },
                { new Note("E"), "6" },
                { new Note("F#"), "7" }
            }
        },
        {
            ScaleName.GSharpMajor,
            new Dictionary<Note, string>
            {
                { new Note("G#"), "1" },
                { new Note("A#"), "2" },
                { new Note("C"), "3" },
                { new Note("C#"), "4" },
                { new Note("D#"), "5" },
                { new Note("F"), "6" },
                { new Note("G"), "7" }
            }
        },
        {
            ScaleName.AMinor,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("B"), "2" },
                { new Note("C"), "b3" },
                { new Note("D"), "4" },
                { new Note("E"), "5" },
                { new Note("F"), "b6" },
                { new Note("G"), "b7" }
            }
        },
        {
            ScaleName.ASharpMinor,
            new Dictionary<Note, string>
            {
                { new Note("A#"), "1" },
                { new Note("C"), "2" },
                { new Note("C#"), "b3" },
                { new Note("D#"), "4" },
                { new Note("F"), "5" },
                { new Note("F#"), "b6" },
                { new Note("G#"), "b7" }
            }
        },
        {
            ScaleName.BMinor,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("C#"), "2" },
                { new Note("D"), "b3" },
                { new Note("E"), "4" },
                { new Note("F#"), "5" },
                { new Note("G"), "b" },
                { new Note("A"), "b7" }
            }
        }
        // Add more scales as needed
    };




    //Retrieve a scale dictionary by name from outside class, using ScaleName.[name_of_scale]
    public static Dictionary<Note, string> GetScaleByName(ScaleName name)
    {
        return AllScales[name];
    }


    public static ScaleName StringToScaleName(string scaleName)
    {
        return (ScaleName)Enum.Parse(typeof(ScaleName), scaleName);
    }


    //TODO, change this to use Chord class? Or maybe just have a function in chord class that returns array of notes
    public static List<ScaleName> ScalesContainingChords(List<Chords.ChordName> chords)
    {
        // List of scales that contain all chords
        List<ScaleName> scalesContainingChords = [];
        
        //For each scale, add the scale if all chords are in the scale
        //done by converting the chords to notes and checking if all notes are in the scale (boolean)
        scalesContainingChords.AddRange(from scale in AllScales let allChordsInScale = chords.All(chordName => Chords.ToNotes(chordName).All(chordNote => scale.Value.Keys.Any(scaleNote => scaleNote.Letter == chordNote.Letter))) where allChordsInScale select scale.Key);
        
        // Return the list of scales containing all chords
        return scalesContainingChords;
    }

}