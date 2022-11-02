using System;

namespace Split.Game.Units.Shared
{
    public interface IHealth
    {
        event Action<int> OnChanged;

        int CurrentHp { get; }
        int MaxHp { get; }
        
        void ApplyDamage(int damage);
        void ApplyHeal(int heal);  
    }
}