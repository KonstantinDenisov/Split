namespace Split.Infrastructure.GameOver
{
    public interface IGameOverService 
    {
        // public event Action OnRestarted;
        void Init();
        void Dispose();
        void ActivateGameOver(bool isActive);
    }
}