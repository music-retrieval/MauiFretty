namespace Fretty.Shared;

public class KeyMetric(string key, double strength): AbstractMetric<string>(key, strength)
{
    public override string ToString()
    {
        return $"Key: {Value} (strength: {Strength})";
    }
}