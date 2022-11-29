using System.Collections;
using TMPro;
using UnityEngine;

namespace Split.Infrastructure
{
    public class TimerScreen : MonoBehaviour
    {
        [Header("Timer UI")]
        [SerializeField] private GameObject _countdown;
        [SerializeField] private TextMeshProUGUI _timerLabel;
        [SerializeField] private int _remainingDuration;

        public void BeginTimer()
        {
            StopAllCoroutines();
            _countdown.SetActive(true);
            StartCoroutine(UpdateTimer());
        }

        private IEnumerator UpdateTimer()
        {
            while (_remainingDuration >= 0)
            {
                UpdateUI(_remainingDuration);
                _remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
        }

        private void UpdateUI(int remainingDuration)
        {
            if (remainingDuration == 0)
            {
                _countdown.SetActive(false);
                return;
            }

            _timerLabel.text = remainingDuration.ToString();
        }

        public void ResetTimer()
        {
            _timerLabel.text = "0";
            _remainingDuration = 0;
        }
    }
}