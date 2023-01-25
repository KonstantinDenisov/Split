using Split.Infrastructure.ServicesFolder.LevelCompletion;
using Split.Infrastructure.ServicesFolder.StartLevel;
using UnityEngine;
using Zenject;

namespace Split.Infrastructure.Pause
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private const string PauseScreenPath = "PauseScreen";
        
        public bool IsPauseActive { get; set; } = true;

        private bool _isPause;
        private bool _isGameOver;
        private PauseScreen _screen;
        private IStartLevelService _startLevelService;
        private ILevelCompletionService _levelCompletionService;

        [Inject]
        public void Construct(IStartLevelService startLevelService, ILevelCompletionService levelCompletionService)
        {
            _startLevelService = startLevelService;
            _levelCompletionService = levelCompletionService;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape) || !IsPauseActive)
                return;
            TogglePause();
        }

        public void Init()
        {
            if (_screen != null)
            {
            }

            CreatePauseScreen();
        }

        private void CreatePauseScreen()
        {
            var prefab = Resources.Load<PauseScreen>(PauseScreenPath);
            _screen = Instantiate(prefab);
            _screen.gameObject.SetActive(false);
            _screen.OnContinue += TogglePause;
            _screen.OnRestart += RestartGame;
            _screen.OnRestartLevel += RestartLevel;
            _screen.OnExit += ExitGame;
        }

        public void Deactivate(bool isActive)
        {
            if (_screen == null)
                return;
            _screen.gameObject.SetActive(false);
            IsPauseActive = false;
        }

        public void Dispose()
        {
            if (_screen == null)
                return;

            _screen.OnContinue -= TogglePause;
            _screen.OnRestart -= RestartGame;
            _screen.OnRestartLevel -= RestartLevel;
            _screen.OnExit -= ExitGame;

            Destroy(_screen.gameObject);
            _screen = null;
        }

        private void RestartLevel()
        {
            TogglePause();
            _levelCompletionService.RestartLevel();
        }

        private void TogglePause()
        {
            _isPause = !_isPause;
            _screen.gameObject.SetActive(_isPause);
            Time.timeScale = _isPause ? 0 : 1;
        }

        private void RestartGame()
        {
            TogglePause();
            _startLevelService.RestartGame();
        }

        private void ExitGame()
        {
            Exit.ExitButtonClicked();
        }
    }
}