using TJC.MVVM.Extensions.Conversion;
using TJC.MVVM.Tests.Mocks;

namespace TJC.MVVM.Tests.Extensions.Conversion;


public class ModelToViewModelConverterTests
{
    [Fact]
    public void RefreshingModelRefreshesViewModel()
    {
        var model = new ModelMock();
        var viewModels = ModelToViewModelConverter.CreateViewModelsFromModels<
            ViewModelMock,
            ModelMock
        >([model]);
        Assert.Equal(1, viewModels.Count);
    }
}
