using Split.Infrastructure.GameOver;
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
        private IGameOverService _gameOverService;

        public LevelCompletionService(ILevelSettingsService levelSettingsService,
            IGameStateMachine stateMachine, IGameWinService gameWinService, IGameOverService gameOverService)
        {
            _levelSettingsService = levelSettingsService;
            _stateMachine = stateMachine;
            _gameWinService = gameWinService;
            _gameOverService = gameOverService;
        }

        public void Init()
        {
        }

        public void Dispose()
        {
        }

        public void MissionCompleted()
        {
            if (_gameOverService.IsGameStop)
                return;
            
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