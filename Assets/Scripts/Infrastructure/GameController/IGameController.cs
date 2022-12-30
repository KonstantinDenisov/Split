namespace Split.Infrastructure.GameController
{
    public interface IGameController
    {
        void Init();
        bool IsGameInit { get; set; }
        void Dispose();
    }
}