using Split.Infrastructure.GameOver;
using Split.Infrastructure.LoadingScreen;
using Split.Infrastructure.SceneLoader;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Mission;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.ServicesFolder.ServicesContainer;

namespace Split.Infrastructure.StateMachine
{
    public static class StateFactory
    {
        public static TState Create<TState>() where TState : class, IExitableState
        {
            return typeof(TState).Name switch
            {
                nameof(BootstrapState) => CreateBootstrapState<TState>(),
                nameof(MenuState) => CreateMenuState<TState>(),
                nameof(GameState) => CreateGameState<TState>(),
                nameof(LoadState) => CreateLoadState<TState>(),
                _ => null
            };
        }

        private static TState CreateBootstrapState<TState>() where TState : class, IExitableState
        {
            var stateMachine = Services.Container.Get<IGameStateMachine>();
            ILevelSettingsService levelSettingsService = null;
            IPersistantService persistantService =
                Services.Container.Get<IPersistantService>();

            return new BootstrapState(stateMachine, levelSettingsService, persistantService) as TState;
        }

        private static TState CreateMenuState<TState>() where TState : class, IExitableState
        {
            var stateMachine = Services.Container.Get<IGameStateMachine>();
            ILoadingScreenService loadingScreenService = null;
            ISceneLoadService sceneLoadService = null;

            return new MenuState(stateMachine, loadingScreenService, sceneLoadService) as TState;
        }

        private static TState CreateLoadState<TState>() where TState : class, IExitableState
        {
            IGameStateMachine stateMachine = Services.Container.Get<IGameStateMachine>();
            ISceneLoadService sceneLoadService = null;
            ILoadingScreenService loadingScreenService = null;
            ILevelSettingsService levelSettingsService = null;

            return new LoadState(stateMachine, sceneLoadService, loadingScreenService, levelSettingsService) as TState;
        }

        private static TState CreateGameState<TState>() where TState : class, IExitableState
        {
            IGameStateMachine stateMachine = Services.Container.Get<IGameStateMachine>();
            ISceneLoadService sceneLoadService = null;
            ILoadingScreenService loadingScreenService = null;
            // INpcService npcService = Services.Container.Get<INpcService>();
            IInputService inputService = null;
            IMissionService missionService = null;
            ILevelSettingsService levelSettingsService = null;
            ILevelCompletionService levelCompletionService = null;
            IPersistantService persistantService = null;
            IPauseService pauseService = null;
            IUIService uiService = null;
            IGameOverService gameOverService = null;

            return new GameState(stateMachine, inputService,
                missionService, levelSettingsService, levelCompletionService, persistantService, pauseService,
                uiService, gameOverService) as TState;
        }
    }
}