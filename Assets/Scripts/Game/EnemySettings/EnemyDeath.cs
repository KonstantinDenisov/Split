using System.Collections;
using UnityEngine;

namespace Split.Game.EnemySettings
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHp _enemyHp;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private float _delay = 3f;
        // public event Action OnDead;
        // public event Action<EnemyDeath> OnHappened;

        private void OnEnable()
        {
            _enemyHp.OnHpChanged += CheckDeath;
        }

        private void OnDisable()
        {
            _enemyHp.OnHpChanged -= CheckDeath;
        }

        private void CheckDeath(int hp)
        {
            if (hp > 0)
                return;

            _enemyHp.OnHpChanged -= CheckDeath;
            StartCoroutine(WaitCoroutine(_delay));


            // OnDead?.Invoke();


            //_enemyAnimation.PlayDeath();
            _collider.enabled = false;
            //enemyDirectMovement.enabled = false;
        }

        private IEnumerator WaitCoroutine(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(_gameObject);
        }
    }
}