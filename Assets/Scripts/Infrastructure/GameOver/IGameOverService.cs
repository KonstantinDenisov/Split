namespace Split.Infrastructure.GameOver
{
    public interface IGameOverService
    {
        void Init();
        void Dispose();
        void ActivateGameOver(bool isActive);
    }
}