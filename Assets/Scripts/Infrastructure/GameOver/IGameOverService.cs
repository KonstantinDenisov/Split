using System;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.GameOver
{
    public interface IGameOverService : IService
    {
        // public event Action OnRestarted;
        void Init();
        void Dispose();
    }
}