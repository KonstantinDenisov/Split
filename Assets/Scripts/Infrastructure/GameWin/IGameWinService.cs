namespace Split.Infrastructure.GameWin
{
    public interface IGameWinService
    {
        void Init();
        void Dispose();
        void ActivateGameWin(bool isActive);
    }
}