using System;
using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.Services.Mission
{
    public interface IMissionService : IService
    {
        event Action OnCompleted;
        
        void Init();
        void Dispose();
    }
}