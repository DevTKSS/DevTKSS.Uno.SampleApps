namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
internal partial record CounterModel
{
    private readonly IStringLocalizer _stringLocalizer;
    public CounterModel(IStringLocalizer stringLocalizer)
    {
        this._stringLocalizer = stringLocalizer;
    }

    public IState<string> CounterTitle => State<string>.Value(this, () => _stringLocalizer["CounterTitle"]);

    public IState<Countable> Countable => State.Value(this, () => new Countable(0, 1));
    public ValueTask IncrementCounter()
        => Countable.UpdateAsync(c => c?.Increment());

    public async Task ReloadCounterTitle()
    {
        await CounterTitle.SetAsync(_stringLocalizer["CounterTitle"]);
    }
}
