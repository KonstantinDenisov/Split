using System;
using System.Collections;
using UnityEngine;

namespace Split.Game.EnemySettings
{
    public class EnemyDeath : MonoBehaviour
    {
        [Header("Particle")]
        [SerializeField] private GameObject _particle;
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private GameObject _gameObject;
        public event Action OnDead;

        private void OnEnable()
        {
            _enemyHp.OnHpChanged += CheckDeath;
        }

        private void CheckDeath(int hp)
        {
            if (hp > 0)
                return;

            _enemyHp.OnHpChanged -= CheckDeath;

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
    }
}