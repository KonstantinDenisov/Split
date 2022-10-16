using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.Mission.KillOneEnemy
{
    public class KillOneEnemyMissionCondition : MissionCondition
    {
        [SerializeField] private GameObject _enemy;

        public GameObject Enemy => _enemy;
    }
}