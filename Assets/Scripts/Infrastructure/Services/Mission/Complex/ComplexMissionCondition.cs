using UnityEngine;

namespace Split.Infrastructure.Services.Mission.Complex
{
    public class ComplexMissionCondition : MissionCondition
    {
        [SerializeField] private MissionCondition[] _conditions;

        public MissionCondition[] Conditions => _conditions;
    }
}