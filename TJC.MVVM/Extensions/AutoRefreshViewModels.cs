using TJC.Singleton;

namespace TJC.MVVM.Extensions;

public sealed class AutoRefreshViewModels : SingletonBase<AutoRefreshViewModels>
{
    public TimeSpan AutoRefreshTime = TimeSpan.FromMinutes(1);

    private AutoRefreshViewModels() => AutoRefresh();

    /// <summary>
    /// Auto Refreshes All View Models
    /// </summary>
    private async void AutoRefresh()
    {
        var task = Task.Run(() =>
        {
            while (true)
            {
                // Refresh UI Elements
                var startTime = DateTime.Now;
                OnAutoRefreshEvent();
                var elapsedTime = startTime - DateTime.Now;

                Thread.Sleep(GetTimeUntilNextRefresh(elapsedTime));
            }
        });
        await task;
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
