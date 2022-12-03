using System;
using Split.Game.Enemy;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.ServicesFolder.Npc
{
    public interface INpcService : IService
    {
        event Action OnAllDead; 
        
        void Init();
        void Dispose();
        void RegisterMovingObject(EnemyMovement enemyMovement);
        void UnregisterObject(EnemyMovement enemyMovement);
        void BeginMove();
    }
}