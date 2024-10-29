using System.Collections.ObjectModel;

namespace TJC.MVVM.ViewModels;

public abstract class ViewModelCollectionBase<T>(ObservableCollection<T> items) : ViewModelBase
    where T : ViewModelBase
{
    public ObservableCollection<T> Items { get; set; } = items;
}
