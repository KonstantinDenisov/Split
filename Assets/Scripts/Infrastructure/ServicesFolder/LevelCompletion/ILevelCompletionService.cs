namespace Split.Infrastructure.ServicesFolder.LevelCompletion
{
    public interface ILevelCompletionService 
    {
        void Init();
        void Dispose();
        void MissionCompleted();
        void RestartLevel();
    }
}