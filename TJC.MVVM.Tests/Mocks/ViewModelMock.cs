using TJC.MVVM.ViewModels;

namespace TJC.MVVM.Tests.Mocks;

internal class ViewModelMock(ModelMock model)
        : ViewModelBase<ModelMock>(model)
{
    public int RefreshCount = 0;

    protected override void DoRefresh(ModelMock model)
    {
        RefreshCount++;
    }
}