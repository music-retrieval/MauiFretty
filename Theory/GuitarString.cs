namespace Fretty.Theory;

public class GuitarString
{
    // Class members go here
    private readonly Note[] _stringNotes;

    public GuitarString(Note rootNote)
    {
        _stringNotes = new Note[25];
        _stringNotes[0] = rootNote;

        for (int i = 1; i < _stringNotes.Length; i++)
        {
            _stringNotes[i] = _stringNotes[i - 1].SemitoneUp();
        }
    }
    
    public GuitarString(string rootNote)
    {
        _stringNotes = new Note[25];
        _stringNotes[0] = new Note(rootNote);

        for (int i = 1; i < _stringNotes.Length; i++)
        {
            _stringNotes[i] = _stringNotes[i - 1].SemitoneUp();
        }
    }


    public override string? ToString()
    {
        return _stringNotes[0].ToString();
    }

    // Returns the note at the given fret
    // where fret 0 is the open string 
    public Note AtFret(int fret) {
        return _stringNotes[fret];
    }

    // Returns the array of Notes that 
    // represents all of the notes on 
    // the Guitar_String
    public Note[] ToNotesArray() {
        return _stringNotes;
    }

    // Returns an array with all of the
    // fretboard positions corresponding
    // to that note
    public int[] FretsOfNote(Note note) {
        var frets = Array.Empty<int>();
        for (var i = 0; i < _stringNotes.Length; i++)
        {
            if (!_stringNotes[i].Equals(note)) continue;
            Array.Resize(ref frets, frets.Length + 1);
            frets[^1] = i;
        }
        return frets;
    }
}
    
    
