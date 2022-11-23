using Split.Infrastructure.GameOver;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure
{
    public class GameState : BaseExitableState, IPayloadState<string>
    {
        //private readonly INpcService _npcService;
        private readonly IInputService _inputService;
        //не понятно
        //private readonly IMissionService _missionService;
        //глобальный?
        private readonly ILevelSettingsService _levelSettingsService;
        //есть локальный
        private readonly ILevelCompletionService _levelCompletionService;
        //глобальный
        private readonly IPersistantService _persistantService;
        
        private readonly IPauseService _pauseService;
        private readonly IUIService _uiService;
        private readonly IGameOverService _gameOverService;

        public GameState(IGameStateMachine gameStateMachine, IInputService inputService, ILevelSettingsService levelSettingsService,
            ILevelCompletionService levelCompletionService, IPersistantService persistantService,
            IPauseService pauseService, IUIService uiService,IGameOverService gameOverService) : base(gameStateMachine)
        {
            _inputService = inputService;
            //_missionService = missionService;
            _levelSettingsService = levelSettingsService;
            _levelCompletionService = levelCompletionService;
            _persistantService = persistantService;
            _pauseService = pauseService;
            _uiService = uiService;
            _gameOverService = gameOverService;
        }

        public void Enter(string sceneName)
        {
           // _levelSettingsService.SetCurrentLevelSettings(sceneName);
            SaveCurrentScene(sceneName);
            Initialize();
            _pauseService.Init();
            _gameOverService.Init();
            _uiService.Init();
        }

        public override void Exit()
        {
            Dispose();
        }

        private void SaveCurrentScene(string sceneName)
        {
            PersistantData data = _persistantService.Data;
            data.LevelData.CurrentSceneId = sceneName;
            _persistantService.Save();
        }

        private void Dispose()
        {
          // _npcService.Dispose();
           //_missionService.Dispose();
           _levelCompletionService.Dispose();
           _gameOverService.Dispose();
           _pauseService.Dispose();
           _uiService.Dispose();
        }

        private void OnSceneLoaded()
        {
            //Initialize();
             //_pauseService.Init();
           //_gameOverService.Init();
            //_uiService.Init();
      
        }

        private void Initialize()
        {
            InitHealth();
        }

        private void InitHealth()
        {
        }

        private void RestartGame()
        {
            Exit();
        }
    }
}