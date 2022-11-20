using System;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure
{
    public interface IPauseService
    {
        public event Action OnRestarted;
        void Init();
        void Dispose();
    }
}