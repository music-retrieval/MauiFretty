using Fretty.Shared;

namespace Fretty.Processing;

// Represents the result of an audio analysis from FrettysEssentia
public class FrettysAnalysis: IAudioAnalysis
{
    public static readonly FrettysAnalysis Empty = new("");
    public static FrettysAnalysis FromResponse(string response) => new(response);
    
    private FrettysAnalysis(string response)
    {
        ParseResponse(response);
    }
    
    private string[]? _chords;
    
    private void ParseResponse(string response)
    {
        _chords = ParseChords(response);
    }
    
    private static string[] ParseChords(string response)
    {
        return response.Split(',');
    }
    
    public string[] Chords()
    {
        return _chords ?? Array.Empty<string>();
    }
}
