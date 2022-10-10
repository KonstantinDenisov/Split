using UnityEngine;

namespace Split.Infrastructure.Services.Mission
{
    public class MissionContainer : MonoBehaviour
    {
        [SerializeField] private MissionCondition _condition;

        public MissionCondition Condition => _condition;
    }
}