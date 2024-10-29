using ReactiveUI;
using TJC.MVVM.Extensions;
using TJC.MVVM.Models;

namespace TJC.MVVM.ViewModels;

public abstract class ViewModelBase<T> : ViewModelBase
    where T : ModelBase
{
    protected ViewModelBase(T model)
    {
        Model = model;
        Refresh();
        Model.RefreshEvent += delegate
        {
            DoRefresh();
        };
    }

    public T Model { get; }

    protected sealed override void DoRefresh()
    {
        if (Model == null)
            return;
        DoRefresh(Model);
    }

    /// <summary>
    /// Refreshes items in the view model for display
    /// </summary>
    protected abstract void DoRefresh(T model);
}

public abstract class ViewModelBase : ReactiveObject
{
    private DateTime _lastRefresh;

    protected ViewModelBase()
    {
        Refresh();
        AutoRefreshViewModels.Instance.AutoRefreshEvent += delegate
        {
            AutoRefresh();
        };
    }

    private void AutoRefresh()
    {
        if (DateTime.Now - _lastRefresh > AutoRefreshViewModels.Instance.AutoRefreshTime)
            Refresh();
    }

    public void Refresh()
    {
        DoRefresh();
        _lastRefresh = DateTime.Now;
    }

    protected abstract void DoRefresh();
}
