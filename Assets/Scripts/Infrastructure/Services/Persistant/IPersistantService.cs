using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.Services.Persistant
{
    public interface IPersistantService : IService
    {
        PersistantData Data { get; }

        void Bootstrap();
        void Save();
    }
}