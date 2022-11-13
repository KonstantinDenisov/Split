using UnityEngine;
using Cinemachine;

namespace Split.Game.CameraServices
{
    public class CameraZoomService : MonoBehaviour
    {
        [Header("Pan")]
        [SerializeField] private float _panSpeed = 2f;
        [SerializeField] private float _panDelta = 1f;
        [SerializeField] private float _panWidthPercent = 0.95f;
        [SerializeField] private float _panHeightPercent = 0.05f;

        [Header("Pan")]
        [SerializeField] private float _zMinValue = -4.30f;
        [SerializeField] private float _zMaxValue = 4.5f;
        [SerializeField] private float _xMinValue = -1.2f;
        [SerializeField] private float _xMaxValue = 1.2f;

        [SerializeField] private CinemachineInputProvider _inputProvider;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        private Transform _cameraTransform;
        private float _target;

        private void Awake()
        {
            _cameraTransform = _virtualCamera.VirtualCameraGameObject.transform;
        }

        private void Update()
        {
            float x = _inputProvider.GetAxisValue(0);
            float y = _inputProvider.GetAxisValue(1);
            float z = _inputProvider.GetAxisValue(2);
            if (x != 0 || z != 0)
                PanScreen(x, y, z);
        }

        public Vector3 PanDirection(float x, float y, float z)
        {
            Vector3 direction = Vector3.zero;
            if (y >= Screen.height * _panWidthPercent && _cameraTransform.position.z <= _zMaxValue)
                direction.z += _panDelta;

            else if (y <= Screen.height * _panHeightPercent && _cameraTransform.position.z >= _zMinValue)
                direction.z -= _panDelta;

            if (x >= Screen.width * _panWidthPercent && _cameraTransform.position.x <= _xMaxValue)
                direction.x += _panDelta;
            else if (x <= Screen.width * _panHeightPercent && _cameraTransform.position.x >= _xMinValue)
                direction.x -= _panDelta;

            return direction;
        }

        public void PanScreen(float x, float y, float z)
        {
            Vector3 direction = PanDirection(x, y, z);
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                _cameraTransform.position + (Vector3) direction * _panSpeed, Time.deltaTime);
        }
    }
}