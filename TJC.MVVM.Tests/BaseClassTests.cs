using System.Collections.ObjectModel;
using TJC.MVVM.Tests.Mocks;
using TJC.MVVM.ViewModels;

namespace TJC.MVVM.Tests;

public class BaseClassTests
{
    [Fact]
    public void ViewModelCollectionBase_StoresProvidedItems()
    {
        var items = new ObservableCollection<ViewModelMock>();
        var viewModel = new CollectionViewModelMock(items);

        Assert.Same(items, viewModel.Items);
    }

    [Fact]
    public void Refresh_UpdatesLastRefreshAndInvokesViewModelRefresh()
    {
        var model = new ModelMock();
        var viewModel = new ViewModelMock(model);

        viewModel.Refresh();

        Assert.Equal(2, viewModel.RefreshCount);
    }

    private sealed class CollectionViewModelMock(ObservableCollection<ViewModelMock> items)
        : ViewModelCollectionBase<ViewModelMock>(items)
    {
        protected override void DoRefresh() { }
    }
}
