using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.Mission.Complex
{
    public class ComplexMissionCondition : MissionCondition
    {
        [SerializeField] private MissionCondition[] _conditions;

        public MissionCondition[] Conditions => _conditions;
    }
}