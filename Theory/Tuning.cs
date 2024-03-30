namespace Fretty.Theory;


public class Tuning
{

    private GuitarString[] _strings;

    public Tuning(GuitarString[] tuning)
    {
        if(tuning.Length == 6) 
        {
            _strings = tuning;
        }
        else
        {
            //Throw exception
            throw new ArgumentException("Invalid number of GuitarStrings.");
        }
    }



    
}
