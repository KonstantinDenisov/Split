using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCaster : MonoBehaviour
    {
        #region Variables

        private Vector2 _frameStartPosition;
        private Vector2 _frameFinishPosition;
        private Camera _mainCamera;
        private UnitState _lastUnit;
        private NavMeshAgent _navMeshAgent;
        private SelectedService _selectedService;
        private CameraRayCasterParams _cameraRayCasterParams;

        #endregion
        
        #region Constructor

        [Inject]
        private void Construct(SelectedService selectedService, CameraRayCasterParams cameraRayCasterParams)
        {
            _selectedService = selectedService;
            _cameraRayCasterParams = cameraRayCasterParams;
        }

        #endregion


        #region Unity Lifecycle

        private void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
            _lastUnit = null;
        }

        private void Update()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _cameraRayCasterParams.InteractiveObjects))
            {
                var interactiveObject = hit.collider.GetComponent<InteractiveObject>();

                if (interactiveObject == null)
                {
                    return;
                }

                if (interactiveObject.InteractiveType == InteractiveType.Unit)
                {
                    if (_lastUnit == null)
                    {
                        IlluminationUnitTurnOn(hit);
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        SelectThisUnit(hit);
                    }
                }

                if (interactiveObject.InteractiveType == InteractiveType.Ground)
                {
                    if (_lastUnit != null)
                    {
                        IlluminationUnitTurnOff();
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        DeselectAllUnits();
                    }

                    if (Input.GetMouseButton(0))
                    {
                        CreateSelectionFrame();
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        _cameraRayCasterParams.FrameImage.enabled = false;
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        if (_selectedService.SelectedUnits != null)
                        {
                            if (_selectedService.SelectedUnits.Count == 1)
                            {
                                if (_selectedService.LossOfControlSwitcher == true)
                                {
                                    ForwardUnit(hit);  
                                }
                            }

                            else
                            {
                                if (_selectedService.LossOfControlSwitcher == true)
                                {
                                    ForwardUnits(hit);  
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
        
        #region Private Methods

        private void IlluminationUnitTurnOn(RaycastHit hit)
        {
            var unit = hit.collider.GetComponent<UnitState>();
            unit.OnHoverEnter();
            _lastUnit = unit;
        }

        private void SelectThisUnit(RaycastHit hit)
        {
            _selectedService.DeselectAllUnits();
            _selectedService.SelectUnit(hit.collider.gameObject);
        }

        private void IlluminationUnitTurnOff()
        {
            _lastUnit.OnHoverExit();
            _lastUnit = null;
        }

        private void DeselectAllUnits()
        {
            _selectedService.DeselectAllUnits();
            _frameStartPosition = Input.mousePosition;
        }

        private void CreateSelectionFrame()
        {
            _frameFinishPosition = Input.mousePosition;

            var min = Vector2.Min(_frameStartPosition, _frameFinishPosition);
            var max = Vector2.Max(_frameStartPosition, _frameFinishPosition);
            var size = max - min;
            
            if (size.magnitude > 10)
            {
                _cameraRayCasterParams.FrameImage.enabled = true;
                _cameraRayCasterParams.FrameImage.rectTransform.anchoredPosition = min;
                _cameraRayCasterParams.FrameImage.rectTransform.sizeDelta = size;

                var rect = new Rect(min, size);
                if(_selectedService.AllUnits.Count==0)
                    return;
                for (var i = 0; i < _selectedService.AllUnits.Count; i++)
                {
                    var unitObject = _selectedService.AllUnits[i];
                    var isUnitSelected = _selectedService.IsUnitSelected(unitObject);
                    if(_mainCamera==null)
                        return;
                    Vector2 screePosition =
                        _mainCamera.WorldToScreenPoint(unitObject.transform.position);
                    if (rect.Contains(screePosition))
                    {
                        if (!isUnitSelected)
                        {
                            _selectedService.SelectUnit(unitObject);
                        }
                    }
                    else
                    {
                        if (isUnitSelected)
                        {
                            _selectedService.DeselectUnit(unitObject);
                        }
                    }
                }
            }
        }

        private void ForwardUnit(RaycastHit hit)
        {
            foreach (var unit in _selectedService.SelectedUnits)
            {
                _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                
                if (_navMeshAgent != null)
                {
                    _navMeshAgent.SetDestination(hit.point);
                }
            }
        }

        private void ForwardUnits(RaycastHit hit)
        {
            var sumX = 0f;
            var sumY = 0f;
            var sumZ = 0f;
            
            foreach (var unit in _selectedService.SelectedUnits)
            {
                var position = unit.transform.position;
                sumX += position.x;
                sumY += position.y;
                sumZ += position.z;
            }

            var centrX = sumX / _selectedService.SelectedUnits.Count;
            var centrY = sumY / _selectedService.SelectedUnits.Count;
            var centrZ = sumZ / _selectedService.SelectedUnits.Count;

            var centralPoint = new Vector3(centrX, centrY, centrZ);

            var distanceToTheTarget = Vector3.Distance(centralPoint, hit.point);

            float groupRadius = 0;

            foreach (var unit in _selectedService.SelectedUnits)
            {
                if (groupRadius < Vector3.Distance(centralPoint, unit.transform.position))
                {
                    groupRadius = Vector3.Distance(centralPoint, unit.transform.position);
                }
            }

            if (groupRadius > distanceToTheTarget)
            {
                foreach (var unit in _selectedService.SelectedUnits)
                {
                    var difference = centralPoint - unit.transform.position;
                    var currentUnitTargetPoint = hit.point - difference / 2;

                    _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                    _navMeshAgent.SetDestination(currentUnitTargetPoint);
                }
            }
            
            else
            {
                foreach (var unit in _selectedService.SelectedUnits)
                {
                    var difference = centralPoint - unit.transform.position;
                    var currentUnitTargetPoint = hit.point - difference;

                    _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                    if (_navMeshAgent != null)
                    {
                        _navMeshAgent.SetDestination(currentUnitTargetPoint);
                    }
                }
            }
        }

        #endregion
    }
}