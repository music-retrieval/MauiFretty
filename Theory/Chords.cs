namespace Fretty.Theory;

public static class Chords
{
    public enum ChordName
    {
        //No one uses sharp chords on guitar, didn't even know they existed, I read its cuz their fingering is too hard
        Invalid,
        
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
                { new Note("C"), "m3" },
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
                { new Note("D"), "m3" },
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
        {
            ChordName.CMajor,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("E"), "3" },
                { new Note("G"), "5" }
            }
        },
        {
            ChordName.CMinor,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D#"), "m3" },
                { new Note("G"), "5" }
            }
        },
        {
            ChordName.C7,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("E"), "3" },
                { new Note("G"), "5" },
                { new Note("A#"), "b7" }
            }
        },
        {
            ChordName.C5,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("G"), "5" }
            }
        },
        {
            ChordName.CDim,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D#"), "m3" },
                { new Note("F#"), "b5" }
            }
        },
        {
            ChordName.CDim7,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D#"), "m3" },
                { new Note("F#"), "b5" },
                { new Note("A"), "bb7" }
            }
        },
        {
            ChordName.CAug,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("E"), "3" },
                { new Note("G#"), "#5" }
            }
        },
        {
            ChordName.CSus2,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D"), "2" },
                { new Note("G"), "5" }
            }
        },
        {
            ChordName.CSus4,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("F"), "4" },
                { new Note("G"), "5" }
            }
        },
        {
            ChordName.CMajor7,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("E"), "3" },
                { new Note("G"), "5" },
                { new Note("B"), "7" }
            }
        },
        {
            ChordName.CMinor7,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("D#"), "m3" },
                { new Note("G"), "5" },
                { new Note("A#"), "b7" }
            }
        },
        {
            ChordName.C7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("C"), "1" },
                { new Note("F"), "4" },
                { new Note("G"), "5" },
                { new Note("A#"), "b7" }
            }
        },
        {
            ChordName.DMajor,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F#"), "3" },
                { new Note("A"), "5" }
            }
        },
        {
            ChordName.DMinor,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F"), "m3" },
                { new Note("A"), "5" }
            }
        },
        {
            ChordName.D7,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F#"), "3" },
                { new Note("A"), "5" },
                { new Note("C"), "b7" }
            }
        },
        {
            ChordName.D5,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("A"), "5" }
            }
        },
        {
            ChordName.DDim,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F"), "m3" },
                { new Note("G#"), "b5" }
            }
        },
        {
            ChordName.DDim7,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F"), "m3" },
                { new Note("G#"), "b5" },
                { new Note("B"), "bb7" }
            }
        },
        {
            ChordName.DAug,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F#"), "3" },
                { new Note("A#"), "#5" }
            }
        },
        {
            ChordName.DSus2,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("E"), "2" },
                { new Note("A"), "5" }
            }
        },
        {
            ChordName.DSus4,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("G"), "4" },
                { new Note("A"), "5" }
            }
        },
        {
            ChordName.DMajor7,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F#"), "3" },
                { new Note("A"), "5" },
                { new Note("C#"), "7" }
            }
        },
        {
            ChordName.DMinor7,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("F"), "m3" },
                { new Note("A"), "5" },
                { new Note("C"), "b7" }
            }
        },
        {
            ChordName.D7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("D"), "1" },
                { new Note("G"), "4" },
                { new Note("A"), "5" },
                { new Note("C"), "b7" }
            }
        },
        {
            ChordName.EMajor,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G#"), "3" },
                { new Note("B"), "5" }
            }
        },
        {
            ChordName.EMinor,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G"), "m3" },
                { new Note("B"), "5" }
            }
        },
        {
            ChordName.E7,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G#"), "3" },
                { new Note("B"), "5" },
                { new Note("D"), "b7" }
            }
        },
        {
            ChordName.E5,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("B"), "5" }
            }
        },
        {
            ChordName.EDim,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G"), "m3" },
                { new Note("A#"), "b5" }
            }
        },
        {
            ChordName.EDim7,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G"), "m3" },
                { new Note("A#"), "b5" },
                { new Note("C#"), "bb7" }
            }
        },
        {
            ChordName.EAug,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G#"), "3" },
                { new Note("C"), "#5" }
            }
        },
        {
            ChordName.ESus2,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("F#"), "2" },
                { new Note("B"), "5" }
            }
        },
        {
            ChordName.ESus4,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("A"), "4" },
                { new Note("B"), "5" }
            }
        },
        {
            ChordName.EMajor7,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G#"), "3" },
                { new Note("B"), "5" },
                { new Note("D#"), "7" }
            }
        },
        {
            ChordName.EMinor7,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("G"), "m3" },
                { new Note("B"), "5" },
                { new Note("D"), "b7" }
            }
        },
        {
            ChordName.E7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("E"), "1" },
                { new Note("A"), "4" },
                { new Note("B"), "5" },
                { new Note("D"), "b7" }
            }
        },
        {
            ChordName.FMajor,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("A"), "3" },
                { new Note("C"), "5" }
            }
        },
        {
            ChordName.FMinor,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("G#"), "m3" },
                { new Note("C"), "5" }
            }
        },
        {
            ChordName.F7,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("A"), "3" },
                { new Note("C"), "5" },
                { new Note("D#"), "b7" }
            }
        },
        {
            ChordName.F5,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("C"), "5" }
            }
        },
        {
            ChordName.FDim,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("G#"), "m3" },
                { new Note("B"), "b5" }
            }
        },
        {
            ChordName.FDim7,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("G#"), "m3" },
                { new Note("B"), "b5" },
                { new Note("D"), "bb7" }
            }
        },
        {
            ChordName.FAug,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("A"), "3" },
                { new Note("D"), "#5" }
            }
        },
        {
            ChordName.FSus2,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("G"), "2" },
                { new Note("C"), "5" }
            }
        },
        {
            ChordName.FSus4,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("A#"), "4" },
                { new Note("C"), "5" }
            }
        },
        {
            ChordName.FMajor7,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("A"), "3" },
                { new Note("C"), "5" },
                { new Note("E"), "7" }
            }
        },
        {
            ChordName.FMinor7,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("G#"), "m3" },
                { new Note("C"), "5" },
                { new Note("D#"), "b7" }
            }
        },
        {
            ChordName.F7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("F"), "1" },
                { new Note("A#"), "4" },
                { new Note("C"), "5" },
                { new Note("D#"), "b7" }
            }
        },
        {
            ChordName.GMajor,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("B"), "3" },
                { new Note("D"), "5" }
            }
        },
        {
            ChordName.GMinor,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("A#"), "m3" },
                { new Note("D"), "5" }
            }
        },
        {
            ChordName.G7,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("B"), "3" },
                { new Note("D"), "5" },
                { new Note("F"), "b7" }
            }
        },
        {
            ChordName.G5,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("D"), "5" }
            }
        },
        {
            ChordName.GDim,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("A#"), "m3" },
                { new Note("C#"), "b5" }
            }
        },
        {
            ChordName.GDim7,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("A#"), "m3" },
                { new Note("C#"), "b5" },
                { new Note("E"), "bb7" }
            }
        },
        {
            ChordName.GAug,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("B"), "3" },
                { new Note("D#"), "#5" }
            }
        },
        {
            ChordName.GSus2,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("A"), "2" },
                { new Note("D"), "5" }
            }
        },
        {
            ChordName.GSus4,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("C"), "4" },
                { new Note("D"), "5" }
            }
        },
        {
            ChordName.GMajor7,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("B"), "3" },
                { new Note("D"), "5" },
                { new Note("F#"), "7" }
            }
        },
        {
            ChordName.GMinor7,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("A#"), "m3" },
                { new Note("D"), "5" },
                { new Note("F"), "b7" }
            }
        },
        {
            ChordName.G7Sus4,
            new Dictionary<Note, string>
            {
                { new Note("G"), "1" },
                { new Note("C"), "4" },
                { new Note("D"), "5" },
                { new Note("F"), "b7" }
            }
        }

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

    public static List<ChordName> ChordsInScale(Scales.ScaleName scale)
    {
        List<ChordName> chordsInScale = [];
        chordsInScale.AddRange(from chord in AllChords 
            let chordNotes = chord.Value.Keys
            let allNotesInScale = chordNotes.All(chordNote => Scales.GetScaleByName(scale).ContainsKey(chordNote)) 
            where allNotesInScale
            select chord.Key);
        
        return chordsInScale;
    }
    
    public static ChordName TryParse(string essentiaChord)
    {
        string chordNameString = essentiaChord.EndsWith('m')
            ? essentiaChord.TrimEnd('m') + "Minor"
            : essentiaChord + "Major";

        return Enum.TryParse(chordNameString, out ChordName chordName)
            ? chordName
            : ChordName.Invalid;
    }
    
    public static ChordName EssentiaToChordName(string essentiaChord)
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
        return (ChordName)Enum.Parse(typeof(ChordName), chordNameString);
    }

    public static List<ChordName> EssentiaToChordNames(List<string> essentiaChords)
    {
        List<ChordName> chordNames = [];

        foreach (string essentiaChord in essentiaChords)
        {
            string chordNameString;
            if (essentiaChord.EndsWith('m'))
            {
                chordNameString = essentiaChord.TrimEnd('m') + "Minor";
            }
            else
            {
                chordNameString = essentiaChord + "Major";
            }

            if (Enum.TryParse(chordNameString, out ChordName chordName))
            {
                chordNames.Add(chordName);
            }
        }

        return chordNames;
    }


}