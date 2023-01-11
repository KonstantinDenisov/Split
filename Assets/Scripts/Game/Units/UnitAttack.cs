using Split.Game.EnemySettings;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitAttack : MonoBehaviour
    {
        [SerializeField] private int _damageEnemy = 1;
        [SerializeField] private float _fireDelay = 0.5f;

        private bool _isAttackActivate;
        private Transform _cachedTransform;

        private float _currentPlayerPosition;
        private EnemyHp _enemyHp;

        private float _timer;

        private bool _isEmptyNear;

        private void Awake() =>
            _cachedTransform = transform;

        private void OnTriggerEnter(Collider col)
        {
            if (!col.gameObject.CompareTag(Tags.Enemy) || _enemyHp != null)
                return;
            _isEmptyNear = true;
            _enemyHp = col.gameObject.GetComponent<EnemyHp>();
        }

        private void Update()
        {
            TickTimer();

            if (CanAttack())
            {
                Attack();
            }
        }

        private void Attack()
        {
            if (!_isEmptyNear || _enemyHp == null)
                return;
            _enemyHp.RemoveHp(_damageEnemy);
            _timer = _fireDelay;
        }

        private bool CanAttack() =>
            _timer <= 0;

        private void Rotate()
        {
            Vector3 unitPosition = UnitAttack.transform.position;
            playerPosition.z = 0f;
        
            Vector3 direction = playerPosition - _cachedTransform.position;
            _cachedTransform.up = direction;
        }

        private void OnTriggerExit(Collider col)
        {
            _enemyHp = null;
        }

        private void TickTimer()
        {
            _timer -= Time.deltaTime;
        }
    }
}