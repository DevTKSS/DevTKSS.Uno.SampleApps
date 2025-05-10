namespace DevTKSS.Uno.Samples.MvuxGallery.Models;

public partial record Countable(int Count, int Step)
{
    public Countable Increment() => this with
    {
        Count = Count + Step
    };
}
