using System;

namespace Split.Infrastructure.Pause
{
    public interface IPauseService
    {
        public event Action OnRestarted;
        bool IsPauseActive { get; set; }
        void Init();
        void Dispose();
    }
}