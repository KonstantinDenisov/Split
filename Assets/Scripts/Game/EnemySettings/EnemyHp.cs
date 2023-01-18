using System;
using UnityEngine;

namespace Split.Game.EnemySettings
{
    public class EnemyHp : MonoBehaviour
    {
        [SerializeField] private int _originalHp;
        [SerializeField] private int _maxHp;

        public int CurrentHp { get; private set; }
        public int MaxHp { get; private set; }

        public event Action<int> OnHpChanged;

        private void Awake()
        {
            CurrentHp = _originalHp;
            MaxHp = _maxHp;
            OnHpChanged?.Invoke(CurrentHp);
        }

        public void AddHp(int hp)
        {
            CurrentHp = Mathf.Min(MaxHp, CurrentHp + hp);
            OnHpChanged?.Invoke(CurrentHp);
        }

        public void RemoveHp(int hp)
        {
            if(CurrentHp<=0)
                return;
            CurrentHp = Mathf.Max(0, CurrentHp - hp);
            OnHpChanged?.Invoke(CurrentHp);
            
            
        }
    }
}