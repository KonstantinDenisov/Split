﻿using System;
using System.Collections;
using UnityEngine;

namespace Split.Game.EnemySettings
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private float _delay = 2000;
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
            _collider.enabled = false;

            StartCoroutine(WaitCoroutine(_delay));
        }

        private IEnumerator WaitCoroutine(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(_gameObject);
            OnDead?.Invoke();
        }
    }
}