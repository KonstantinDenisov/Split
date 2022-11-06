using Split.Infrastructure.GameOver;
using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.ServicesFolder.Persistant;

namespace Split.Infrastructure.StateMachine
{
    public class GameState : BaseExitableState, IPayloadState<string>
    {
        private readonly ISceneLoadService _sceneLoadService;
        private readonly ILoadingScreenService _loadingScreenService;
        private readonly INpcService _npcService;
        private readonly IInputService _inputService;
        private readonly IMissionService _missionService;
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly ILevelCompletionService _levelCompletionService;
        private readonly IPersistantService _persistantService;
        private readonly IPauseService _pauseService;
        private readonly IUIService _uiService;
        private readonly IGameOverService _gameOverService;

        public GameState(IGameStateMachine gameStateMachine, ISceneLoadService sceneLoadService,
            ILoadingScreenService loadingScreenService, INpcService npcService, IInputService inputService,
            IMissionService missionService, ILevelSettingsService levelSettingsService,
            ILevelCompletionService levelCompletionService, IPersistantService persistantService,
            IPauseService pauseService, IUIService uiService,IGameOverService gameOverService) : base(gameStateMachine)
        {
            _sceneLoadService = sceneLoadService;
            _loadingScreenService = loadingScreenService;
            _npcService = npcService;
            _inputService = inputService;
            _missionService = missionService;
            _levelSettingsService = levelSettingsService;
            _levelCompletionService = levelCompletionService;
            _persistantService = persistantService;
            _pauseService = pauseService;
            _uiService = uiService;
            _gameOverService = gameOverService;
        }

        public void Enter(string sceneName)
        {
            _levelSettingsService.SetCurrentLevelSettings(sceneName);
            SaveCurrentScene(sceneName);

            _loadingScreenService.ShowScreen();
            _sceneLoadService.Load(sceneName, OnSceneLoaded);
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
            _npcService.Dispose();
            _missionService.Dispose();
            _levelCompletionService.Dispose();
            _gameOverService.Dispose();
            _pauseService.Dispose();
            _uiService.Dispose();
        }

        private void OnSceneLoaded()
        {
            Initialize();
            _loadingScreenService.HideScreen();
            _pauseService.Init();
            _gameOverService.Init();
            _uiService.Init();
      
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