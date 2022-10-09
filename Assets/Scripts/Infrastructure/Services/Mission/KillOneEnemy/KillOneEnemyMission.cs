using Split.Game.Enemy;
namespace Split.Infrastructure.Services.Mission.KillOneEnemy
{
    public class KillOneEnemyMission : Mission<KillOneEnemyMissionCondition>
    {
        private EnemyDeath _enemyDeath;
        
        public override void Init()
        {
            _enemyDeath = Condition.Enemy.GetComponentInChildren<EnemyDeath>();

            if (_enemyDeath == null)
            {
                // TODO: log error
                return;
            }

            _enemyDeath.OnHappened += EnemyDead;
        }

        public override void Dispose()
        {
            _enemyDeath.OnHappened -= EnemyDead;
            _enemyDeath = null;
        }

        private void EnemyDead(EnemyDeath enemyDeath) =>
            Complete();
    }
}