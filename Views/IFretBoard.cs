namespace Fretty.Views;

public interface IFretBoard
{
    void DrawChord(string note, IEnumerable<int[]> coordinates, string? numberedNote);
    
    void UpdateScalePicker(List<string> scales);
}