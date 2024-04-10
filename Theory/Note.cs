namespace Fretty.Theory;

public struct Note
{
    //a list of all potential note values in the musical alphabet
    private readonly string[] _allNotes = ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"];

    private string _letter;

    public Note(string letter)
    {
        if (Array.IndexOf(_allNotes, letter) == -1)
        {
            throw new ArgumentException("Invalid note value.");
        }
        _letter = letter;
    }

    public string Letter
    {
        get => _letter;

        //Notes are done using # notation rather than b notation
        set
        {
            if (Array.IndexOf(_allNotes, value) != -1)
            {
                _letter = value;
            }
            else
            {
                throw new ArgumentException("Invalid note value.");
            }
        }
    }


    public Note SemitoneUp() 
    {
        int index = Array.IndexOf(_allNotes, _letter);
        
        int newIndex = index >= _allNotes.Length - 1 ? 0 : index + 1;
        
        return new Note(_allNotes[newIndex]);
    }

    public Note SemitoneDown()
    {
        int index = Array.IndexOf(_allNotes, _letter);
        
        int newIndex = index == 0 ? _allNotes.Length - 1 : index - 1;

        return new Note(_allNotes[newIndex]);
    }
}


