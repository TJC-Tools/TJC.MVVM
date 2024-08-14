using TJC.MVVM.Extensions.Conversion;
using TJC.MVVM.Tests.Mocks;

namespace TJC.MVVM.Tests.Extensions.Conversion;

[TestClass]
public class ModelToViewModelConverterTests
{
    [TestMethod]
    public void RefreshingModelRefreshesViewModel()
    {
        var model = new ModelMock();
        var viewModels = ModelToViewModelConverter.CreateViewModelsFromModels<ViewModelMock, ModelMock>([model]);
        Assert.AreEqual(1, viewModels.Count);
    }
}