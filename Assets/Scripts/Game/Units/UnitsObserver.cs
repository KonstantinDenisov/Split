using System;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitsObserver : MonoBehaviour,IUnitsObserver
    {
        private int _unitsCount;
        public static event Action<bool> OnDead;

        private void Start()
        {
            Units[] units = FindObjectsOfType<Units>();
            _unitsCount = units.Length;

            foreach (Units unit in units)
            {
                unit.OnDestroyed += UnitsDestroyed;
            }
        }

        private void UnitsDestroyed()
        {
            _unitsCount--;
            if (_unitsCount == 0)
            {
                OnDead?.Invoke(true);
            }
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}