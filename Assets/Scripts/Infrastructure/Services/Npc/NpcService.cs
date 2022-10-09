using System;
using System.Collections.Generic;
using System.Linq;
using Split.Game.Enemy;
using Object = UnityEngine.Object;

namespace Split.Infrastructure.Services.Npc
{
    public class NpcService : INpcService
    {
        public event Action OnAllDead;

        private List<EnemyDeath> _enemies;

        public void Init()
        {
            EnemyStarter[] enemyStarters = Object.FindObjectsOfType<EnemyStarter>();

            foreach (EnemyStarter starter in enemyStarters)
                starter.Begin();

            _enemies = Object.FindObjectsOfType<EnemyDeath>().ToList();
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
            _enemies = null;
        }

        private void Unsubscribe()
        {
            foreach (EnemyDeath enemyDeath in _enemies)
                enemyDeath.OnHappened -= OnEnemyDead;
        }

        private void Subscribe()
        {
            foreach (EnemyDeath enemyDeath in _enemies)
                enemyDeath.OnHappened += OnEnemyDead;
        }

        private void OnEnemyDead(EnemyDeath enemyDeath)
        {
            enemyDeath.OnHappened -= OnEnemyDead;
            _enemies.Remove(enemyDeath);

            if (_enemies.Count == 0)
            {
                OnAllDead?.Invoke();
            }
        }
    }
}