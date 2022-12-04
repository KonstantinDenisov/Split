using System;
using Split.Infrastructure.ServicesFolder.StartLevel;
using Split.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Split.Infrastructure.Pause
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private const string PauseScreenPath = "PauseScreen";

        public bool IsPauseActive { get; set; } = true;

        private bool _isPause;
        private PauseScreen _screen;
        private IStartLevelService _startLevelService;

        [Inject]
        public void Construct(IStartLevelService startLevelService)
        {
            _startLevelService = startLevelService;
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
            PauseScreen prefab = Resources.Load<PauseScreen>(PauseScreenPath);
            _screen = Instantiate(prefab);
            _screen.gameObject.SetActive(false);
            _screen.OnContinue += TogglePause;
            _screen.OnRestart += RestartGame;
            _screen.OnExit += ExitGame;
        }

        public void Dispose()
        {
            if (_screen == null)
            {
            }

            _screen.OnContinue -= TogglePause;
            _screen.OnRestart -= RestartGame;
            _screen.OnExit -= ExitGame;

            Destroy(_screen.gameObject);
            _screen = null;
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

        public void GameWin(bool gameOver)
        {
            if (gameOver)
                IsPauseActive = true;
        }
    }
}