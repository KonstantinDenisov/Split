using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.ServicesFolder.Persistant;
using UnityEngine;

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

        public GameState(IGameStateMachine gameStateMachine, ISceneLoadService sceneLoadService,
            ILoadingScreenService loadingScreenService, INpcService npcService, IInputService inputService,
            IMissionService missionService, ILevelSettingsService levelSettingsService,
            ILevelCompletionService levelCompletionService, IPersistantService persistantService) : base(gameStateMachine)
        {
            _sceneLoadService = sceneLoadService;
            _loadingScreenService = loadingScreenService;
            _npcService = npcService;
            _inputService = inputService;
            _missionService = missionService;
            _levelSettingsService = levelSettingsService;
            _levelCompletionService = levelCompletionService;
            _persistantService = persistantService;
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
        }

        private void OnSceneLoaded()
        {
            Initialize();
            _loadingScreenService.HideScreen();
        }

        private void Initialize()
        {
            InitHealth();
            _npcService.Init();

            _missionService.Init();
            _levelCompletionService.Init();
        }

        private void InitHealth()
        {
        }
    }
}