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
        var index = Array.IndexOf(_allNotes, _letter);

        if (index == 11)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        return new Note(_allNotes[index]);
    }

    public Note SemitoneDown()
    {
        var index = Array.IndexOf(_allNotes, _letter);
        
        if(index == 0) 
        {
            index = 11;
        }
        else 
        {
            index -= 1;
        }

        return new Note(_allNotes[index]);
    }
}


