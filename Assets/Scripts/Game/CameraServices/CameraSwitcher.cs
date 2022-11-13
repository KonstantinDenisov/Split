using Cinemachine;
using UnityEngine;

namespace Split.Game.CameraServices
{
    public class CameraSwitcher : MonoBehaviour

    {
        [Header("Cameras")]
        [SerializeField] private CinemachineVirtualCamera _minCamera;
        [SerializeField] private CinemachineVirtualCamera _maxCamera;

        [Header("Priorities")]
        [SerializeField] private int _minPriority;
        [SerializeField] private int _maxPriority=10;
        

        private void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                _maxCamera.Priority = _minPriority;
                _minCamera.Priority = _maxPriority;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                _maxCamera.Priority = _maxPriority;
                _minCamera.Priority = _minPriority;
            }
        }
    }
}