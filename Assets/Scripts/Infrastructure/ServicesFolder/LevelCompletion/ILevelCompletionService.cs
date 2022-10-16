using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.ServicesFolder.LevelCompletion
{
    public interface ILevelCompletionService : IService
    {
        void Init();
        void Dispose();
    }
}