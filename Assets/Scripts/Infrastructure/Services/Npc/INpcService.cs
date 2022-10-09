using System;
using Split.Infrastructure.Services.ServicesContainer;

namespace Split.Infrastructure.Services.Npc
{
    public interface INpcService : IService
    {
        event Action OnAllDead; 
        
        void Init();
        void Dispose();
    }
}