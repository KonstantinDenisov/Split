using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.LoadingScreen
{
    public interface ILoadingScreenService : IService
    {
        void ShowScreen();
        void HideScreen();
    }
}