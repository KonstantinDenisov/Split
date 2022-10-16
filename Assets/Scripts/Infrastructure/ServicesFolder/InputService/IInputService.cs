using Split.Infrastructure.ServicesFolder.ServicesContainer;
using UnityEngine;

namespace Split.Infrastructure.ServicesFolder.InputService
{
    public interface IInputService : IService
    {
        Vector2 Axes { get; }
        Vector3 LookDirection { get; }

        void Init(Camera camera, Transform playerMovementTransform);
    }
}