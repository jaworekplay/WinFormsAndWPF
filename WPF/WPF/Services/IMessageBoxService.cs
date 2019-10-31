using ViewModel;

namespace WPF.Services
{
    public interface IMessageBoxService
    {
        bool? Render(BaseViewModel baseViewModel);
    }
}