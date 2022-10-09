using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.Services.LevelCompletion
{
    public interface ILevelCompletionService : IService
    {
        void Init();
        void Dispose();
    }
}