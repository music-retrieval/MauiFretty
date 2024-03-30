namespace Fretty.Theory;

// Class holding all scales and scale-related functions
public class Scales
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
        ASharp,
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
        }
        // Add more scales as needed
    };




    //Retrieve a scale dictionary by name from outside class, using ScaleName.[name_of_scale]
    public static Dictionary<Note, string> GetScaleByName(ScaleName name)
    {
        return AllScales[name];
    }





    //TODO, change this to use Chord class? Or maybe just have a function in chord class that returns array of notes
    public static List<ScaleName> ScalesContainingChords(Note[][] chords)
    {
        // List of scales that contain all chords
        List<ScaleName> scalesContainingChords = new List<ScaleName>();

        // Check each scale to see if it contains all chords
        foreach (var scale in AllScales)
        {
            // Check if all chords are in the scale
            bool allChordsInScale = true;
            foreach (var chord in chords)
            {
                if (!chord.All(chordNote => scale.Value.Keys.Any(scaleNote => scaleNote.Letter == chordNote.Letter)))
                {
                    // If any chord is not in the scale, break and check the next scale
                    allChordsInScale = false;
                    break;
                }
            }
            // If all chords are in the scale, add the scale to the list
            if (allChordsInScale)
            {
                scalesContainingChords.Add(scale.Key);
            }
        }

        // Return the list of scales containing all chords
        return scalesContainingChords;
    }

}