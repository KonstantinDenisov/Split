using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.ServicesFolder.Persistant
{
    public interface IPersistantService : IService
    {
        PersistantData Data { get; }

        void Bootstrap();
        void Save();
    }
}