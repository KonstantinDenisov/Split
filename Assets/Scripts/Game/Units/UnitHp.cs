using System;
using Split.Game.Units.Shared;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitHp : MonoBehaviour, IHealth
    {
        [SerializeField] private int _startHp;
        [SerializeField] private int _maxHp;
        
        public event Action<int> OnChanged;
        
        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        private void Awake()
        {
            CurrentHp = _startHp;
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp -= damage;
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyHeal(int heal)
        {
            CurrentHp = Mathf.Min(_maxHp, CurrentHp + heal);
            OnChanged?.Invoke(CurrentHp);
        }
    }
}