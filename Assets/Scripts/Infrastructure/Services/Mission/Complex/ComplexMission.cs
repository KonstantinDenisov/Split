
using Split.Utility;

namespace Split.Infrastructure.Services.Mission.Complex
{
    public class ComplexMission : Mission<ComplexMissionCondition>
    {
        private Mission[] _missions;

        private int _completedMission;

        public override void Init()
        {
            MissionCondition[] conditions = Condition.Conditions;
            _missions = MissionFactory.Create(conditions);

            foreach (var mission in _missions)
            {
                mission.OnCompleted += MissionCompleted;
                mission.Init();
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            // TODO: Dont update mission if completed
            _missions.ForEach(x => x.Update(deltaTime));
        }

        public override void Dispose()
        {
            _missions.ForEach(x => x.OnCompleted -= MissionCompleted);
            _missions.ForEach(x => x.Dispose());
        }

        private void MissionCompleted()
        {
            _completedMission++;

            if (_missions.Length == _completedMission)
            {
                Complete();
            }
        }
    }
}