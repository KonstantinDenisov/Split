using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.InputService
{
    public class StandaloneInputService : IInputService
    {
        private Camera _mainCamera;
        private Transform _playerMovementTransform;

        public Vector2 Axes => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public Vector3 LookDirection => GetLookDirection();

        public void Init(Camera camera, Transform playerMovementTransform)
        {
            _mainCamera = camera;
            _playerMovementTransform = playerMovementTransform;
        }

        private Vector3 GetLookDirection()
        {
            var mousePosition = Input.mousePosition;
            var worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;
            return worldPoint - _playerMovementTransform.position;
        }
    }
}