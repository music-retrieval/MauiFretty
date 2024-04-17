using Fretty.Theory;

namespace Fretty.Views;

public interface IFretBoard
{
    void DrawChord(string note, IEnumerable<int[]> coordinates);
    
    void UpdateScalePicker(List<string> scales);
}