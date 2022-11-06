using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Game.Units
{
    public interface IUnitsObserver:IService
    {
        void Init();
        void Dispose();
    }
}