using Fretty.Theory;

namespace Fretty.Views;

public interface IFretBoard
{
    void GenerateAllOfNote(string note, IEnumerable<int[]> coordinates, string? numberedNote);
    
    void UpdateScalePicker(List<string> scales);
}