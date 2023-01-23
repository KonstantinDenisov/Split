using System.Collections;
using UnityEngine;

namespace Split.Game.Objects
{
    public class FlameDestruction : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        
        private void Start()
        {
            StartCoroutine(DelayDeathTime());
        }
        
        private IEnumerator DelayDeathTime()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}