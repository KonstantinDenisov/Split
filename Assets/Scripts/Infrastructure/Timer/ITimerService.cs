using Cysharp.Threading.Tasks;

namespace Split.Infrastructure
{
    public interface ITimerService
    {
        void Init();
        void Dispose();
        UniTask Timer();
    }
}