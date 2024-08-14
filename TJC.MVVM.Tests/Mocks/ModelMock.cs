using TJC.MVVM.Models;

namespace TJC.MVVM.Tests.Mocks;

internal class ModelMock : ModelBase
{
    public void RunRefresh() =>
        OnRefresh();
}