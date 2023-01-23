using System;

namespace Split.Infrastructure.ServicesFolder.Mission
{
    public interface IMissionService 
    {
        event Action OnCompleted;
        
        void Init();
        void Dispose();
    }
}