namespace DevTKSS.Extensions.Uno.Storage.Enumerables;

public record Lines()
{
    public Lines(int start, int end) : this()
    {
        Start = start;
        End = end;
    }
    public int Start { get; init; } = 0;
    public int End { get; init; } = 0;
}
