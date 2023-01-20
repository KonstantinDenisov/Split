using System.Collections;
using Split.Infrastructure;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitDeath : MonoBehaviour
    {
        [SerializeField] private UnitHp _unitHp;
        [SerializeField] private GameObject _unit;
        [SerializeField] private UnitAnimation _unitAnimation;
        [SerializeField] private float _lifeTime = 3f;

        private GameState _gameState;

        public bool IsDead { get; private set; }

        private void Start() =>
            _unitHp.OnChanged += OnHpChanged;

        private void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;

            _unitAnimation.SetIsDead();
            IsDead = true;

            StartCoroutine(DelayDeathTime());
        }

        private IEnumerator DelayDeathTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(_unit);
        }
    }
}