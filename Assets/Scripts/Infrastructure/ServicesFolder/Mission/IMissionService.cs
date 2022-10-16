using System;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.ServicesFolder.Mission
{
    public interface IMissionService : IService
    {
        event Action OnCompleted;
        
        void Init();
        void Dispose();
    }
}