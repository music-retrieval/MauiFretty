namespace Fretty.Theory;

public struct Note
{
    //a list of all potential note values in the musical alphabet
    private readonly string[] _allNotes = ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"];

    public string Letter { get; }

    public Note(string letter)
    {
        if (Array.IndexOf(_allNotes, letter) == -1)
        {
            throw new ArgumentException("Invalid note value.");
        }
        Letter = letter;
    }

    


    public Note SemitoneUp() 
    {
        int index = Array.IndexOf(_allNotes, Letter);
        
        int newIndex = index >= _allNotes.Length - 1 ? 0 : index + 1;
        
        return new Note(_allNotes[newIndex]);
    }

    public Note SemitoneDown()
    {
        int index = Array.IndexOf(_allNotes, Letter);
        
        int newIndex = index == 0 ? _allNotes.Length - 1 : index - 1;

        return new Note(_allNotes[newIndex]);
    }
}


