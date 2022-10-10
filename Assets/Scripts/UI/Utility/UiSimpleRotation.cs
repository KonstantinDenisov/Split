using UnityEngine;

namespace Split.UI.Utility
{
    public class UiSimpleRotation : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _speed;

        private RectTransform _rectTransform;

        private float _delayTimer;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            UpdateTimer();

            if (CanRotate())
            {
                Rotate();
            }
        }

        private void Rotate()
        {
            Vector3 eulerAngles = _rectTransform.rotation.eulerAngles;
            eulerAngles.z += _speed * Time.deltaTime;
            _rectTransform.rotation = Quaternion.Euler(eulerAngles);
        }

        private bool CanRotate() =>
            _delayTimer >= _delay;

        private void UpdateTimer() =>
            _delayTimer += Time.deltaTime;
    }
}