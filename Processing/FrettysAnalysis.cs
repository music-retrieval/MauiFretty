using Fretty.Shared;
using Fretty.Theory;
using Newtonsoft.Json.Linq;

namespace Fretty.Processing;

// Represents the result of an audio analysis from FrettysEssentia
public class FrettysAnalysis: IAudioAnalysis
{
    public static FrettysAnalysis FromResponse(string response) => new(response);
    
    private FrettysAnalysis(string response)
    {
        JObject jsonObject = JObject.Parse(response);
        ParseResponse(jsonObject);
    }
    
    private ChordMetric[]? _chords;
    private KeyMetric? _key;
    
    private void ParseResponse(JObject response)
    {
        IJEnumerable<JToken>? chords = response["chords"]?.AsJEnumerable();
        _chords = ParseChords(chords ?? new JArray());

        JToken? key = response["key"];
        _key = ParseKey(key ?? new JObject());
    }
    
    private static ChordMetric[] ParseChords(IEnumerable<JToken> response)
    {
        return (from chord in response
            let value = chord["chord"].ToString()
            let strength = chord["strength"].ToObject<double>()
            select new ChordMetric(value, strength)).ToArray();
    }
    
    private static KeyMetric ParseKey(JToken response)
    {
        JToken key = response["key"] ?? new JObject();
        JToken strength = response["strength"] ?? new JObject();
        return new KeyMetric(key.ToString(), strength.ToObject<double>());
    }
    
    public IEnumerable<ChordMetric> Chords()
    {
        return _chords ?? [];
    }
    
    public IEnumerable<Chords.ChordName> ChordProgression()
    {
        return _chords?
            .Where(chord => chord.Strength < 0.5)
            .Where(chord => chord.IsSharpOrFlat())
            .OrderBy(chord => chord.Strength)
            .Distinct()
            .Select(chord => chord.Value)
            .ToArray() ?? new Chords.ChordName[] { };
    }

    public KeyMetric Key()
    {
        return _key ?? new KeyMetric("", 0);
    }
}
