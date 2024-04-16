namespace Fretty.Theory;

public struct Note
{
    //a list of all potential note values in the musical alphabet
    private static readonly string[] AllNotes = ["A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#"];

    public string Letter { get; }
    
    public Note(string letter)
    {
        if (Array.IndexOf(AllNotes, letter) == -1)
        {
            throw new ArgumentException("Invalid note value.");
        }
        Letter = letter;
    }


    public Note SemitoneUp() 
    {
        int index = Array.IndexOf(AllNotes, Letter);
        
        int newIndex = index >= AllNotes.Length - 1 ? 0 : index + 1;
        
        return new Note(AllNotes[newIndex]);
    }

    public Note SemitoneDown()
    {
        int index = Array.IndexOf(AllNotes, Letter);
        
        int newIndex = index == 0 ? AllNotes.Length - 1 : index - 1;

        return new Note(AllNotes[newIndex]);
    }
}


