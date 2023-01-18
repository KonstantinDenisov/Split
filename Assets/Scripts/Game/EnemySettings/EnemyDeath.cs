using System;
using UnityEngine;

namespace Split.Game.EnemySettings
{
    public class EnemyDeath : MonoBehaviour
    {
        [Header("Particle")]
        [SerializeField] private GameObject _particle;
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Collider _cachedTriggerCollider;
        public event Action OnDead;
        public event Action OnDeadAnimation;
        public bool IsDead { get; set; }

        private void OnEnable()
        {
            _enemyHp.OnHpChanged += CheckDeath;
            IsDead = true;
        }

        private void CheckDeath(int hp)
        {
            if (hp > 0)
                return;
            IsDead = false;
            
            _cachedTriggerCollider.enabled = false;
            _enemyHp.OnHpChanged -= CheckDeath;
            OnDeadAnimation?.Invoke();
            
            SpawnVfx();
            if (_gameObject == null)
                return;
            Destroy(_gameObject);
            OnDead?.Invoke();
        }

        private void SpawnVfx()
        {
            Instantiate(_particle, transform.position, Quaternion.identity);
        }

        public bool Dead(bool isDead)
        {
            return isDead;
        }
    }
}