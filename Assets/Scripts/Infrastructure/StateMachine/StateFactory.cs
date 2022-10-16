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
    public static class StateFactory
    {
        public static TState Create<TState>() where TState : class, IExitableState
        {
            return typeof(TState).Name switch
            {
                nameof(BootstrapState) => CreateBootstrapState<TState>(),
                nameof(MenuState) => CreateMenuState<TState>(),
                nameof(GameState) => CreateGameState<TState>(),
                _ => null
            };
        }

        private static TState CreateGameState<TState>() where TState : class, IExitableState
        {
            IGameStateMachine stateMachine = ServicesFolder.ServicesContainer.Services.Container.Get<IGameStateMachine>();
            ISceneLoadService sceneLoadService = ServicesFolder.ServicesContainer.Services.Container.Get<ISceneLoadService>();
            ILoadingScreenService loadingScreenService = ServicesFolder.ServicesContainer.Services.Container.Get<ILoadingScreenService>();
            INpcService npcService = ServicesFolder.ServicesContainer.Services.Container.Get<INpcService>();
            IInputService inputService = ServicesFolder.ServicesContainer.Services.Container.Get<IInputService>();
            IMissionService missionService = ServicesFolder.ServicesContainer.Services.Container.Get<IMissionService>();
            ILevelSettingsService levelSettingsService = ServicesFolder.ServicesContainer.Services.Container.Get<ILevelSettingsService>();
            ILevelCompletionService levelCompletionService = ServicesFolder.ServicesContainer.Services.Container.Get<ILevelCompletionService>();
            IPersistantService persistantService = ServicesFolder.ServicesContainer.Services.Container.Get<IPersistantService>();

            return new GameState(stateMachine, sceneLoadService, loadingScreenService, npcService, inputService,
                missionService, levelSettingsService, levelCompletionService, persistantService) as TState;
        }

        private static TState CreateMenuState<TState>() where TState : class, IExitableState
        {
            var stateMachine = ServicesFolder.ServicesContainer.Services.Container.Get<IGameStateMachine>();

            return new MenuState(stateMachine) as TState;
        }

        private static TState CreateBootstrapState<TState>() where TState : class, IExitableState
        {
            var stateMachine = ServicesFolder.ServicesContainer.Services.Container.Get<IGameStateMachine>();
            ILevelSettingsService levelSettingsService = ServicesFolder.ServicesContainer.Services.Container.Get<ILevelSettingsService>();
            IPersistantService persistantService = ServicesFolder.ServicesContainer.Services.Container.Get<IPersistantService>();

            return new BootstrapState(stateMachine, levelSettingsService, persistantService) as TState;
        }
    }
}