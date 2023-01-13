using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Split.Game.EnemySettings;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.LevelCompletion;

namespace Split.Infrastructure.ServicesFolder.Npc
{
    public class NpcService : INpcService
    {
        private ILevelCompletionService _levelCompletionService;
       
        public NpcService(ILevelCompletionService levelCompletionService )
        {
            _levelCompletionService = levelCompletionService;
           
        }

        public event Action OnAllDead;

        private List<EnemyMovement> _enemies = new();

        public void Init()
        {
        }

        public void RegisterMovingObject(EnemyMovement enemyMovement)
        {
            _enemies.Add(enemyMovement);
        }

        public async void UnregisterObject(EnemyMovement enemyMovement)
        {
            if (_enemies == null )
                return;

            _enemies.Remove(enemyMovement);

            if (_enemies.Count == 0)
            {
                OnAllDead?.Invoke();
                await UniTask.Delay(5000);
                _levelCompletionService.MissionCompleted();
            }
        }

        public void Dispose()
        {
            _enemies = null;
        }

        public void BeginMove()
        {
            if (_enemies == null)
                return;
            foreach (EnemyMovement enemyMovement in _enemies)
            {
                enemyMovement.InitMove();
            }
        }
    }
}