using System;
using UnityEngine;

namespace Split.Infrastructure
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private const string PauseScreenPath = "PauseScreen";

        public event Action OnRestarted;

        private bool _isPause = false;
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
                Debug.LogError(" ISN'T NULL Error");
            }

            CreatePauseScreen();
        }
        
        private void CreatePauseScreen()
        {
            Debug.LogWarning("CreatePauseScreen Begin");
            PauseScreen prefab = Resources.Load<PauseScreen>(PauseScreenPath);
            Debug.LogWarning($"CreatePauseScreen prefab '{prefab}'");
            _screen = Instantiate(prefab);

            _screen.gameObject.SetActive(false);
            _screen.OnContinue += TogglePause;
            _screen.OnRestart += RestartGame;
            Debug.LogWarning($"CreatePauseScreen End screen '{_screen.gameObject}'");
        }
        
        
        

        public void Dispose()
        {
            if (_screen == null)
            {
                Debug.LogError("NULL");
            }

            _screen.OnContinue -= TogglePause;
            _screen.OnRestart -= RestartGame;

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
    }
}




