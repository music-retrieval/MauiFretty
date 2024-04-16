namespace Fretty.Theory;

public class Tuning
{
    public GuitarString[] Strings { get; }

    //Default to standard tuning
    public Tuning(GuitarString[] strings)
    {
        if (strings.Length != 6)
        {
            throw new ArgumentException("Invalid number of strings.");
        }

        Strings = strings;
    }

    public Tuning(string[] strings)
    {
        if (strings.Length != 6)
        {
            throw new ArgumentException("Invalid number of strings.");
        }

        Strings = new GuitarString[]
        {
            new GuitarString(new Note(strings[0])),
            new GuitarString(new Note(strings[1])),
            new GuitarString(new Note(strings[2])),
            new GuitarString(new Note(strings[3])),
            new GuitarString(new Note(strings[4])),
            new GuitarString(new Note(strings[5]))
        };
    }

    public override string? ToString()
    {
        // returns the array of Strings.ToString()
        // TODO, make sure this is returned in the correct order, so that EADGBE is returned as EADGBE
        return string.Join("", Strings.Select(s => s.ToString()));
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

