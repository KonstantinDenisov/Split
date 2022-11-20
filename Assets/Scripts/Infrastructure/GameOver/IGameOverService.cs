using System;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.GameOver
{
    public interface IGameOverService 
    {
        // public event Action OnRestarted;
        void Init();
        void Dispose();
    }
}