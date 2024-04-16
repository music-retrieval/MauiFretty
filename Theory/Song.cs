namespace Fretty.Theory;
using static Chords;

public class Song(string songName, Key songKey, List<ChordName> songChords)
{
    //Suggests scales that contain the notes from the chords in the song
    public List<Scales.ScaleName> SuggestScales(){
        return Scales.ScalesContainingChords(songChords);
    }

    //Adds a chord to the Song instance's songChords
    public void AddChord(ChordName newChord){
        songChords.Add(newChord);
    }

    //Removes a chord from the Song instance's songChords
    public void RemoveChord(ChordName badChord)
    {
        songChords.Remove(badChord);
    }

    //Changes the name of the song
    public void ChangeName(string name){
        songName = name;
    }
}
