namespace Split.Infrastructure.GameOver
{
    public interface IGameOverService
    {
        bool IsGameOver { get; set; }
        bool IsGameStop { get; set; }
        void Init();
        void Dispose();
        void ActivateGameOver(bool isActive);
    }
}