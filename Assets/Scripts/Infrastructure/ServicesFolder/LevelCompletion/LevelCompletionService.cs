using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure.ServicesFolder.LevelCompletion
{
    public class LevelCompletionService : ILevelCompletionService
    {
        private readonly IMissionService _missionService;
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly IGameStateMachine _stateMachine;

        public LevelCompletionService(IMissionService missionService, ILevelSettingsService levelSettingsService,
            IGameStateMachine stateMachine)
        {
            _missionService = missionService;
            _levelSettingsService = levelSettingsService;
            _stateMachine = stateMachine;
        }

        public void Init()
        {
            _missionService.OnCompleted += MissionCompleted;
        }

        public void Dispose()
        {
            _missionService.OnCompleted -= MissionCompleted;
        }

        private void MissionCompleted()
        {
            LevelSettings currentLevelSetting = _levelSettingsService.GetCurrentLevelSetting();

            if (currentLevelSetting.NextLevel == null)
            {
                return;
            }

            _stateMachine.Enter<GameState, string>(currentLevelSetting.NextLevel.SceneName);
        }
    }
}