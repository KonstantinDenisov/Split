using System;
using TMPro;
using UnityEngine;

namespace Split.UI
{
    public class UITimer:MonoBehaviour
    {
        [SerializeField] private float _timer;
        [SerializeField] private TextMeshProUGUI _timerLabel;

        private void Update()
        {
            _timer += Time.deltaTime;
            DisplayTime(_timer);
        }

        private void DisplayTime(float timeToDisplay)
        {
            float minutes = Mathf.FloorToInt(timeToDisplay/60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            _timerLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}