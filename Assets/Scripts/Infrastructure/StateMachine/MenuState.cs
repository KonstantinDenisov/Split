using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;

namespace Split.Infrastructure.StateMachine
{
    public class MenuState : BaseState
    {
        private ILoadingScreenService _loadingScreenService;
        private ISceneLoadService _sceneLoadService;

        public MenuState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            Services.ServicesContainer.Services.Container.Get(out _loadingScreenService);
            Services.ServicesContainer.Services.Container.Get(out _sceneLoadService);

            _loadingScreenService.ShowScreen();
            _sceneLoadService.Load("MenuScene", OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            _loadingScreenService.HideScreen();
        }

        public override void Exit()
        {
            _loadingScreenService = null;
            _sceneLoadService = null;
        }
    }
}