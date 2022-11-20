using Split.Infrastructure;
using Split.Infrastructure.StateMachine;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitDeath:MonoBehaviour
    {
        [SerializeField] private UnitHp _unitHp;
        [SerializeField] private GameObject _unit;
        
        private GameState _gameState;

        public bool IsDead { get; private set; }

        private void Start() =>
            _unitHp.OnChanged += OnHpChanged;

        
        private void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;

            IsDead = true;
            Destroy(_unit);
        }
    }
}