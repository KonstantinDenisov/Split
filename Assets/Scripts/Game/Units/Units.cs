using System;
using UnityEngine;

namespace Split.Game.Units
{
    public class Units : MonoBehaviour

    {
        public event Action OnDestroyed;

        private void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }
    }
}