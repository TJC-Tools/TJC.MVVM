using System.Collections.ObjectModel;
using TJC.MVVM.Tests.Mocks;
using TJC.MVVM.ViewModels;

namespace TJC.MVVM.Tests;

[TestClass]
public class BaseClassTests
{
    [TestMethod]
    public void ViewModelCollectionBase_StoresProvidedItems()
    {
        var items = new ObservableCollection<ViewModelMock>();
        var viewModel = new CollectionViewModelMock(items);

        Assert.AreSame(items, viewModel.Items);
    }

    [TestMethod]
    public void Refresh_UpdatesLastRefreshAndInvokesViewModelRefresh()
    {
        var model = new ModelMock();
        var viewModel = new ViewModelMock(model);

        viewModel.Refresh();

        Assert.AreEqual(2, viewModel.RefreshCount);
    }

    private sealed class CollectionViewModelMock(ObservableCollection<ViewModelMock> items)
        : ViewModelCollectionBase<ViewModelMock>(items)
    {
        protected override void DoRefresh() { }
    }
}
