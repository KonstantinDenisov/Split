using System;

namespace Split.Infrastructure.Pause
{
    public interface IPauseService
    {
        bool IsPauseActive { get; set; }
        void Deactivate(bool isActive);
        void Init();
        void Dispose();
    }
}