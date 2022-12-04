using System;

namespace Split.Infrastructure.Pause
{
    public interface IPauseService
    {
        bool IsPauseActive { get; set; }
        void Init();
        void Dispose();
    }
}