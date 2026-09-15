using TJC.MVVM.Tests.Mocks;

namespace TJC.MVVM.Tests.Refreshing;


public class ModelToViewModelConverterTests
{
    [Fact]
    public void RefreshingModelRefreshesViewModel()
    {
        var model = new ModelMock();
        var viewModel = new ViewModelMock(model);
        Assert.Equal(1, viewModel.RefreshCount);
        model.RunRefresh();
        Assert.True(
            2 == viewModel.RefreshCount,
            "Another Refresh Occurs when the Model Refreshes"
        );
    }
}
