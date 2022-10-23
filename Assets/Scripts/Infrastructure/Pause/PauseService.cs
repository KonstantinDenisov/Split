using System;
using UnityEngine;

namespace Split.Infrastructure
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private const string PauseScreenPath = "PauseScreen";

        public event Action OnRestarted;

        private bool _isPause;
        private PauseScreen _screen;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
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

        private void RestartGame() =>
            OnRestarted?.Invoke();

        private void ExitGame()
        {
            Exit.ExitButtonClicked();
        }
    }
}