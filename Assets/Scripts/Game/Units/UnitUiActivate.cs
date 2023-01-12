using UnityEngine;

namespace Split.Game.Units
{
    public class UnitUiActivate : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        private void Awake()
        {
            Diactivate();
        }

        public void Activate()
        {
            _gameObject.SetActive(true);
            Debug.Log("UnitUiActivate");
        }

        public void Diactivate()
        {
            _gameObject.SetActive(false);
        }
    }
}