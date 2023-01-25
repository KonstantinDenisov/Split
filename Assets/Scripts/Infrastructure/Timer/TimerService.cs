using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Split.Infrastructure
{
    public class TimerService : MonoBehaviour, ITimerService
    {
        private const string GameStateScreenPath = "GameStateScreen";
        private int _remainingDuration = 5;
        private TimerScreen _timerScreen;

        public void Init()
        {
            CreateUIScreen();
        }

        public void CreateUIScreen()
        {
            if (_timerScreen != null)
                return;

            TimerScreen prefab = Resources.Load<TimerScreen>(GameStateScreenPath);
            _timerScreen = Instantiate(prefab);
            _timerScreen.gameObject.SetActive(true);
        }

        private void UpdateUI(int remainingDuration)
        {
            if(_timerScreen==null)
                return;
            
            _timerScreen.SetLabel(_remainingDuration);

            if (remainingDuration == 0)
            {
                _timerScreen.ActivateCountdown(false);
            }
        }

        private void ResetTimer()
        {
            _timerScreen.SetLabel(0);
            _remainingDuration = 0;
        }

        public async UniTask Timer()
        {
            _timerScreen.ActivateCountdown(true);
            while (_remainingDuration >= 0)
            {
                await UniTask.Delay(1000);
                UpdateUI(_remainingDuration);
                _remainingDuration--;
            }
        }

        public void Dispose()
        {
            if (_timerScreen == null)
                return;

            ResetTimer();
            Destroy(_timerScreen.gameObject);
            _timerScreen = null;
        }
    }
}