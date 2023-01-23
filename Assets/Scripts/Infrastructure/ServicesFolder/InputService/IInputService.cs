using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.InputService
{
    public interface IInputService
    {
        Vector2 Axes { get; }
        Vector3 LookDirection { get; }

        void Init(Camera camera, Transform playerMovementTransform);
    }
}