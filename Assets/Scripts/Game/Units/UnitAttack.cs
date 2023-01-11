using Split.Game.EnemySettings;
using UnityEngine;

namespace Split.Game.Units
{
    public class UnitAttack : MonoBehaviour
    {
        [SerializeField] private int _damageEnemy = 1;
        [SerializeField] private float _fireDelay = 0.5f;
        [SerializeField] private float _turnSpeed = 1f;
        [SerializeField] private Transform _unitTransform;
        [SerializeField] private Transform _transform;

        private bool _isAttackActivate;
        private Transform _cachedTransform;
        private Quaternion _rotGoal;

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
            Rotate();

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
            //Vector3 difference = (_enemyHp.transform.position - _cachedTransform.position).normalized;
            Vector3 difference = (_transform.position- _unitTransform.position).normalized;
            _rotGoal = Quaternion.LookRotation(difference);
            _unitTransform.rotation = Quaternion.Slerp(_unitTransform.rotation, _rotGoal, _turnSpeed);
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