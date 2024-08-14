namespace TJC.MVVM.Models;

public abstract class ModelBase
{
    protected void OnRefresh() =>
    RefreshEvent?.Invoke(this, EventArgs.Empty);

    public event EventHandler? RefreshEvent;
}