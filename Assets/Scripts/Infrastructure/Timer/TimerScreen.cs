﻿using System;
using TMPro;
using UnityEngine;

namespace Split.Infrastructure
{
    public class TimerScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerLabel;
        [SerializeField] private GameObject _countdown;

        public void ActivateCountdown(bool isActive)
        {
            _countdown.SetActive(isActive);
        }
        
        public void SetLabel(int label)
        {
            _timerLabel.text = label.ToString();
        }
    }
}