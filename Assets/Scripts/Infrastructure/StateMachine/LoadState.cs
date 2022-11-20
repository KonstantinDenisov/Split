using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.StateMachine;

namespace Split.Infrastructure
{
    public class LoadState : BaseExitableState, IPayloadState<string>
    {
        private readonly ISceneLoadService _sceneLoadService;
        private readonly ILoadingScreenService _loadingScreenService;
        private readonly ILevelSettingsService _levelSettingsService;
        private string _sceneName;

        public LoadState(IGameStateMachine gameStateMachine, ISceneLoadService sceneLoadService,
            ILoadingScreenService loadingScreenService, ILevelSettingsService levelSettingsService) : base(
            gameStateMachine)
        {
            _sceneLoadService = sceneLoadService;
            _loadingScreenService = loadingScreenService;
            _levelSettingsService = levelSettingsService;
        }

        public void Enter(string sceneName)
        {
            _levelSettingsService.SetCurrentLevelSettings(sceneName);
            _loadingScreenService.ShowScreen();
            _sceneLoadService.Load(sceneName, OnSceneLoaded);
            _sceneName = sceneName;
        }

        private void OnSceneLoaded()
        {
            _loadingScreenService.HideScreen();
            StateMachine.Enter<LoadState, string>(_sceneName);
            _loadingScreenService.HideScreen();
            Exit();
        }

        public override void Exit()
        {
        }
    }
}