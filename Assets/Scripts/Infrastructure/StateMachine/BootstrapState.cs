using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.Utility.Coroutine;
using Zenject;

namespace Split.Infrastructure.StateMachine
{
    public class BootstrapState : BaseState
    {
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly IPersistantService _persistantService;
        private ICoroutineRunner _coroutineRunner;

        public BootstrapState(IGameStateMachine gameStateMachine, ILevelSettingsService levelSettingsService,
            IPersistantService persistantService) : base(gameStateMachine)
        {
            _levelSettingsService = levelSettingsService;
            _persistantService = persistantService;
        }
        
        [Inject]
        public void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public override void Enter()
        {
            _levelSettingsService.Bootstrap();
            _persistantService.Bootstrap();
            
            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
        }
    }
}