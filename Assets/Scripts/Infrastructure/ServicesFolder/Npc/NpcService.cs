using System;
using System.Collections.Generic;
using Split.Game.EnemySettings;

namespace Split.Infrastructure.ServicesFolder.Npc
{
    public class NpcService : INpcService
    {
        public event Action OnAllDead;

        private List<EnemyMovement> _enemies = new();

        public void Init()
        {
        }
        public void RegisterMovingObject(EnemyMovement enemyMovement)
        {
            _enemies.Add(enemyMovement);
        }

        public void UnregisterObject(EnemyMovement enemyMovement)
        {
            if (_enemies ==null)
                return;
            
            _enemies.Remove(enemyMovement);
            
            if (_enemies.Count == 0)
            {
                OnAllDead?.Invoke();
            }
    
        }
        public void Dispose()
        {
            _enemies = null;
        }

        public void BeginMove()
        {  
            if (_enemies ==null)
                return;
            foreach (EnemyMovement enemyMovement in _enemies)
            {
                enemyMovement.StartMove();
            }
        }
    }
}