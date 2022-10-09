
using UnityEngine;

namespace Split.Infrastructure.Services.Mission.KillOneEnemy
{
    public class KillOneEnemyMissionCondition : MissionCondition
    {
        [SerializeField] private GameObject _enemy;

        public GameObject Enemy => _enemy;
    }
}