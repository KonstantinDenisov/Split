using Split.Game.Units.SelectedFolder;
using Split.Infrastructure.GameController;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.GameWin;
using Split.Infrastructure.Pause;
using Split.Infrastructure.ServicesFolder.InputService;
using Split.Infrastructure.ServicesFolder.Level;
using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.Npc;
using Split.Infrastructure.ServicesFolder.Persistant;
using Split.Infrastructure.StateMachine;
using Split.Infrastructure.UnitRegisterService;

namespace Split.Infrastructure
{
    public class GameState : BaseExitableState, IPayloadState<string>
    {
        private readonly INpcService _npcService;
        private readonly IInputService _inputService;
        private readonly ILevelSettingsService _levelSettingsService;
        private readonly ILevelCompletionService _levelCompletionService;
        private readonly IPersistantService _persistantService;

        private readonly IPauseService _pauseService;
        private readonly ITimerService _timerService;
        private readonly IGameOverService _gameOverService;
        private readonly IGameController _gameController;
        private readonly IUnitRegisterService _registerService;
        private readonly IGameWinService _gameWinService;
        private readonly SelectedService _selectedService;
        private readonly CameraRayCaster _cameraRayCaster;

        public GameState(IGameStateMachine gameStateMachine, INpcService npcService, IInputService inputService,
            ILevelSettingsService levelSettingsService,
            ILevelCompletionService levelCompletionService, IPersistantService persistantService,
            IPauseService pauseService, ITimerService timerService, IGameOverService gameOverService,
            IGameController gameController, IUnitRegisterService unitRegisterService, IGameWinService gameWinService,
            SelectedService selectedService,CameraRayCaster cameraRayCaster) : base(gameStateMachine)
        {
            _npcService = npcService;
            _inputService = inputService;
            _levelSettingsService = levelSettingsService;
            _levelCompletionService = levelCompletionService;
            _persistantService = persistantService;
            _pauseService = pauseService;
            _timerService = timerService;
            _gameOverService = gameOverService;
            _gameController = gameController;
            _registerService = unitRegisterService;
            _gameWinService = gameWinService;
            _selectedService = selectedService;
            _cameraRayCaster = cameraRayCaster;
        }

        public void Enter(string sceneName)
        {
            SaveCurrentScene(sceneName);
            Initialize();
            _npcService.Init();
            _pauseService.Init();
            _gameOverService.Init();
            _timerService.Init();
            _gameController.Init();
            _gameWinService.Init();
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
            _levelCompletionService.Dispose();
            _gameOverService.Dispose();
            _pauseService.Dispose();
            _timerService.Dispose();
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