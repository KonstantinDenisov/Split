using Split.Infrastructure.Services.Mission;
using UnityEngine;

namespace TDS.Game.Mission
{
    public class MissionContainer : MonoBehaviour
    {
        [SerializeField] private MissionCondition _condition;

        public MissionCondition Condition => _condition;
    }
}