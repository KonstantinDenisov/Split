using System;
using Split.Game.Enemy;


namespace Split.Infrastructure.ServicesFolder.Npc
{
    public interface INpcService 
    {
        event Action OnAllDead; 
        
        void Init();
        void Dispose();
        void RegisterMovingObject(EnemyMovement enemyMovement);
        void UnregisterObject(EnemyMovement enemyMovement);
        void BeginMove();
    }
}