using Cinemachine;
using UnityEngine;

namespace Split.Game.CameraServices
{
    public class CameraSwitcher : MonoBehaviour

    {
        [SerializeField] private CinemachineVirtualCamera _minCamera;
        [SerializeField] private CinemachineVirtualCamera _maxCamera;

        private bool _overWorldCamera = true;

        private void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                SwitchPriority();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                SwitchPriority();
            }
        }

        private void SwitchPriority()
        {
            if (_overWorldCamera)
            {
                _maxCamera.Priority = 10;
                _minCamera.Priority = 0;
            }
            else
            {
                _maxCamera.Priority = 0;
                _minCamera.Priority = 10;
            }

            _overWorldCamera = !_overWorldCamera;
        }
    }
}