namespace Fretty.Theory;



public class Tuning
{
    public GuitarString[] Strings { get; }

    //Default to standard tuning
    public Tuning(GuitarString[] strings)
    {
        Strings = new GuitarString[]
        {
            new GuitarString(new Note("E")),
            new GuitarString(new Note("A")),
            new GuitarString(new Note("D")),
            new GuitarString(new Note("G")),
            new GuitarString(new Note("B")),
            new GuitarString(new Note("E"))
        };
    }
    
    
    //3 overloading methods for changing the tuning of a string
    public void ChangeString(int stringNumber, GuitarString newString)
    {
        Strings[stringNumber] = newString;
    }
    public void ChangeString(int stringNumber, Note newRootNote)
    {
        Strings[stringNumber] = new GuitarString(newRootNote);
    }
    public void ChangeString(int stringNumber, string newRootNote)
    {
        Strings[stringNumber] = new GuitarString(new Note(newRootNote));
    }
}

