using TJC.Singleton;

namespace TJC.MVVM.Extensions;

public sealed class AutoRefreshViewModels : SingletonBase<AutoRefreshViewModels>
{
    public TimeSpan AutoRefreshTime = TimeSpan.FromMinutes(1);
    private readonly Timer _timer;

    private AutoRefreshViewModels() =>
        _timer = new(AutoRefresh, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);

    /// <summary>
    /// Auto Refreshes All View Models
    /// </summary>
    private void AutoRefresh(object? state)
    {
        // Refresh UI Elements
        var startTime = DateTime.Now;
        OnAutoRefreshEvent();
        var elapsedTime = DateTime.Now - startTime;

        _timer.Change(GetTimeUntilNextRefresh(elapsedTime), Timeout.InfiniteTimeSpan);
    }

    private void OnAutoRefreshEvent() => AutoRefreshEvent?.Invoke(null, EventArgs.Empty);

    public event EventHandler? AutoRefreshEvent;

    /// <summary>
    /// Get Time to Sleep before Next Refresh
    /// Ensure it is longer than it takes to refresh, so we don't trigger multiple refreshes at once
    /// </summary>
    /// <param name="elapsedTime"></param>
    /// <returns></returns>
    private TimeSpan GetTimeUntilNextRefresh(TimeSpan elapsedTime) =>
        AutoRefreshTime > 2 * elapsedTime ? AutoRefreshTime : 2 * elapsedTime;
}
