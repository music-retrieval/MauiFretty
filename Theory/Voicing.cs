
namespace Fretty.Theory;
//TODO: Determine whether this should be a
//      Struct or a CLass, given that essentially
//      It's an array of restricted values
//      I think since it's an array it should 
//      stay as a class, but I could make
//      the fret position a Struct (int between -1 and 24)
//      This however could just be over-object-orienting

public class Voicing
{

    // The name of the chord is dependent
    // on the tuning, and so should be stored
    // in a Tuning instance in a dictionary
    // style, with {Chord: Voicing1, Voicing2, etc}
    private int[] _positions;

    public Voicing(int[] fretPositions, int[] positions)
    {
        //TODO: add a check to make sure 
        //      that the values fall between
        //      -1 and 24
        if(fretPositions.Length == 6)
        {
            _positions = fretPositions;
        }
        else
        {
            throw new ArgumentException("Invalid number of fret positions.");
        }
    }


}