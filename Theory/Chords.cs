namespace Fretty.Theory;

public class Chords
{
    public enum ChordName
    {
        //No one uses sharp chords on guitar, didn't even know they existed, I read its cuz their fingering is too hard

        //A Scales
        AMajor,
        AMinor,
        A7,
        A5,
        ADim,
        ADim7,
        AAug,
        ASus2,
        ASus4,
        AMajor7,
        AMinor7,
        A7Sus4,
        //There are many more variations, view https://www.all-guitar-chords.com/chords/scales to see the rest
        // These are the most common though

        //B Scales
        BMajor,
        BMinor,
        B7,
        B5,
        BDim,
        BDim7,
        BAug,
        BSus2,
        BSus4,
        BMajor7,
        BMinor7,
        B7Sus4,

        //C Scales
        CMajor,
        CMinor,
        C7,
        C5,
        CDim,
        CDim7,
        CAug,
        CSus2,
        CSus4,
        CMajor7,
        CMinor7,
        C7Sus4,

        //D Scales
        DMajor,
        DMinor,
        D7,
        D5,
        DDim,
        DDim7,
        DAug,
        DSus2,
        DSus4,
        DMajor7,
        DMinor7,
        D7Sus4,

        //E Scales
        EMajor,
        EMinor,
        E7,
        E5,
        EDim,
        EDim7,
        EAug,
        ESus2,
        ESus4,
        EMajor7,
        EMinor7,
        E7Sus4,

        //F Scales
        FMajor,
        FMinor,
        F7,
        F5,
        FDim,
        FDim7,
        FAug,
        FSus2,
        FSus4,
        FMajor7,
        FMinor7,
        F7Sus4,

        //G Scales
        GMajor,
        GMinor,
        G7,
        G5,
        GDim,
        GDim7,
        GAug,
        GSus2,
        GSus4,
        GMajor7,
        GMinor7,
        G7Sus4

        // Add more chord types as needed
    }

    private static readonly Dictionary<ChordName, Dictionary<Note, string>> AllChords = new Dictionary<ChordName, Dictionary<Note, string>>
    {
        {
            ChordName.AMajor,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C#"), "3" },
                { new Note("E"), "5" }
            }
        },
        {
            ChordName.AMinor,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C"), "b3" },
                { new Note("E"), "5" }
            }
        },
        {
            ChordName.A7,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C#"), "3" },
                { new Note("E"), "5" },
                { new Note("G"), "b7" }
            }
        },
        {
            ChordName.A5,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("E"), "5" }
            }
        },
        {
            ChordName.ADim,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C"), "m3" },
                { new Note("D#"), "b5" }
            }
        },
        {
            ChordName.ADim7, 
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C"), "m3" },
                { new Note("D#"), "b5" },
                { new Note("F#"), "bb7" }
            }
        },
        {
            ChordName.AAug,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C#"), "3" },
                { new Note("F"), "#5" }
            }
        },
        {
            ChordName.ASus2,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("B"), "2" },
                { new Note("E"), "5" }
            }
        },
        {
            ChordName.ASus4,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("D"), "4" },
                { new Note("E"), "5" }
            }
        },
        {
            ChordName.AMajor7,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C#"), "3" },
                { new Note("E"), "5" },
                { new Note("G#"), "7" }
            }
        },
        {
            ChordName.AMinor7,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("C"), "m3" },
                { new Note("E"), "5" },
                { new Note("G"), "b7" }
            }
        },
        {
            ChordName.A7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("A"), "1" },
                { new Note("D"), "4" },
                { new Note("E"), "5" },
                { new Note("G"), "b7" }
            }
        },

        {
            ChordName.BMajor,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D#"), "3" },
                { new Note("F#"), "5" }
            }
        },
        {
            ChordName.BMinor,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D"), "b3" },
                { new Note("F#"), "5" }
            }
        },
        {
            ChordName.B7,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D#"), "3" },
                { new Note("F#"), "5" },
                { new Note("A"), "b7" }
            }
        },
        {
            ChordName.B5,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("F#"), "5" }
            }
        },
        {
            ChordName.BDim,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D"), "m3" },
                { new Note("F"), "b5" }
            }
        },
        {
            ChordName.BDim7,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D"), "m3" },
                { new Note("F"), "b5" },
                { new Note("G#"), "bb7" }
            }
        },
        {
            ChordName.BAug,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D#"), "3" },
                { new Note("G"), "#5" }
            }
        },
        {
            ChordName.BSus2,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("C#"), "2" },
                { new Note("F#"), "5" }
            }
        },
        {
            ChordName.BSus4,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("E"), "4" },
                { new Note("F#"), "5" }
            }
        },
        {
            ChordName.BMajor7,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D#"), "3" },
                { new Note("F#"), "5" },
                { new Note("A#"), "7" }
            }
        },
        {
            ChordName.BMinor7,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("D"), "m3" },
                { new Note("F#"), "5" },
                { new Note("A"), "b7" }
            }
        },
        {
            ChordName.B7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("B"), "1" },
                { new Note("E"), "4" },
                { new Note("F#"), "5" },
                { new Note("A"), "b7" }
            }
        },

        // Add more chords and their intervals using https://www.scales-chords.com/chord/guitar/B7sus4
    };

    public static Dictionary<Note, string> GetChordNotes(ChordName name)
    {
        return AllChords[name];
    }


    public static List<ChordName> ChordsContainingNotes(Note[] notes)
    {
        List<ChordName> chordsContainingNotes = new List<ChordName>();

        foreach (var chord in AllChords)
        {
            bool allNotesInChordName = notes.All(chordNote => chord.Value.Keys.Any(chordKey => chordKey.Letter == chordNote.Letter));
            
            if (allNotesInChordName)
            {
                chordsContainingNotes.Add(chord.Key);
            }
        }

        return chordsContainingNotes;
    }
    
    public static Note[] ToNotes(ChordName name)
    {
        return AllChords[name].Keys.ToArray();
    }

}