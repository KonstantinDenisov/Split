using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using UnityEngine;

namespace Split.Infrastructure.StateMachine
{
    public class MenuState : BaseState
    {
        private ILoadingScreenService _loadingScreenService;
        private ISceneLoadService _sceneLoadService;

        public MenuState(IGameStateMachine gameStateMachine, ILoadingScreenService loadingScreenService,
            ISceneLoadService sceneLoadService) : base(gameStateMachine)
        {
            _loadingScreenService = loadingScreenService;
            _sceneLoadService = sceneLoadService;
        }

        public override void Enter()
        {
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