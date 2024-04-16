namespace Fretty.Shared;

public abstract class AbstractMetric<T>(T value, double strength)
{
    public T Value { get; set; } = value;
    public double Strength { get; set; } = strength;
}