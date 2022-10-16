using System;
using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.Mission
{
    public class MissionService : MonoBehaviour, IMissionService
    {
        private const string Tag = nameof(MissionService);

        private ServicesFolder.Mission.Mission _currentMission;

        public event Action OnCompleted;

        private void Update()
        {
            if (_currentMission != null && !_currentMission.IsCompleted)
                _currentMission?.Update(Time.deltaTime);
        }

        public void Init()
        {
            MissionContainer container = FindObjectOfType<MissionContainer>();

            if (container == null)
            {
                return;
            }

            MissionCondition condition = container.Condition;
            _currentMission = MissionFactory.Create(condition);
            _currentMission.OnCompleted += MissionCompleted;
            _currentMission.Init();
        }

        public void Dispose()
        {
            _currentMission.OnCompleted -= MissionCompleted;
            _currentMission.Dispose();
        }

        private void MissionCompleted()
        {
            OnCompleted?.Invoke();
        }
    }
}