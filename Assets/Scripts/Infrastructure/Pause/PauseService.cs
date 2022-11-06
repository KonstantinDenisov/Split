using System;
using Split.Game.Units;
using UnityEngine;

namespace Split.Infrastructure.Pause
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private const string PauseScreenPath = "PauseScreen";

        private bool IsGameOver{get; set; }

        public event Action OnRestarted;

        private bool _isPause;
        private PauseScreen _screen;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape) || IsGameOver)
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
            UnitsObserver.OnDead += GameOver;

        }

        public void Dispose()
        {
            if (_screen == null)
            {
            }

            _screen.OnContinue -= TogglePause;
            _screen.OnRestart -= RestartGame;
            _screen.OnExit -= ExitGame;
            UnitsObserver.OnDead -= GameOver;

            Destroy(_screen.gameObject);
            _screen = null;
        }

        private void TogglePause()
        {
            _isPause = !_isPause;
            _screen.gameObject.SetActive(_isPause);
            Time.timeScale = _isPause ? 0 : 1;
        }

        private void RestartGame() =>
            OnRestarted?.Invoke();

        private void ExitGame()
        {
            Exit.ExitButtonClicked();
        }

        private void GameOver(bool gameOver)
        {
            if(gameOver)
                IsGameOver = true;
        }
    }
}