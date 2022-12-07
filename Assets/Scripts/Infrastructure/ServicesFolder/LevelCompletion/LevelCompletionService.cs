using Split.Infrastructure.GameWin;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure.ServicesFolder.LevelCompletion
{
    public class LevelCompletionService : ILevelCompletionService
    {
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IGameWinService _gameWinService;

        public LevelCompletionService( ILevelSettingsService levelSettingsService,
            IGameStateMachine stateMachine,IGameWinService gameWinService)
        {
            _levelSettingsService = levelSettingsService;
            _stateMachine = stateMachine;
            _gameWinService = gameWinService;
        }

        public void Init()
        {
        }

        public void Dispose()
        {
        }

        public void MissionCompleted()
        {
            LevelSettings currentLevelSetting = _levelSettingsService.GetCurrentLevelSetting();
            
            if (currentLevelSetting.NextLevel == null)
            {
                _gameWinService.ActivateGameWin(true);
                return;
            }
            
            _stateMachine.Enter<LoadState, string>(currentLevelSetting.NextLevel.SceneName);
        }

        public void RestartLevel()
        {
            LevelSettings currentLevelSetting = _levelSettingsService.GetCurrentLevelSetting();
            _stateMachine.Enter<LoadState, string>(currentLevelSetting.SceneName);
        }
    }
}