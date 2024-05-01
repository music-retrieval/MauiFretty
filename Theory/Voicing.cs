
namespace Fretty.Theory;
//Related to chords not scales, so not urgent

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
    
    // However, we've gone with the abstract form of tuning
    // Meaning tunings can take any form, and so we can't
    // store the name of the chord in the tuning as there
    // are so many possibilities. This means we need to add
    // a property to the Voicing class to store the tuning
    // of the chord. This will be a Tuning instance.
    
    // In order to optimize searches, I think that the
    // tuning needs to be the key for a dictionary, 
    // with the value being a list of voicings.
    // However, this would only be optimal if the tuning
    // had a string representation, meaning we need to
    // add a ToString() method to the Tuning class.
    // Or maybe just add a .Equals() method to the Tuning
    // class that is faster than the default .Equals() method
    
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