using Microsoft.UI.Xaml.Data;

namespace UnoHotDesignApp1.Presentation.Models;
[Bindable]
internal partial record CounterModel
{
    public CounterModel()
    {
    }

    public IState<Countable> Countable => State.Value(this, () => new Countable(0, 1));
    public ValueTask IncrementCounter()
        => Countable.UpdateAsync(c => c?.Increment());

}
