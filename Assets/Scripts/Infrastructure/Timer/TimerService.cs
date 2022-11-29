using UnityEngine;

namespace Split.Infrastructure
{
    public class TimerService : MonoBehaviour, ITimerService
    {
        private const string GameStateScreenPath = "GameStateScreen";

        private TimerScreen _timerScreen;

        public void Init()
        {
            if (_timerScreen != null)
            {
            }

            CreateUIScreen();
        }

        private void CreateUIScreen()
        {
            TimerScreen prefab = Resources.Load<TimerScreen>(GameStateScreenPath);
            _timerScreen = Instantiate(prefab);

            _timerScreen.gameObject.SetActive(true);

            _timerScreen.BeginTimer();
        }

        public void Dispose()
        {
            if (_timerScreen == null)
            {
            }

            _timerScreen.ResetTimer();
            Destroy(_timerScreen.gameObject);
            _timerScreen = null;
        }
    }
}