using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure
{
    public interface IUIService:IService
    {
        void Init();

        void Dispose();

    }
}