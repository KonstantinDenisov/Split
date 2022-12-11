using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCaster : MonoBehaviour
    {
        #region Variables

        [SerializeField] private LayerMask _unitLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _interactiveObjects;
        [SerializeField] private Image _frameImage;
        private Vector2 _frameStartPosition;
        private Vector2 _frameFinishPosition;
        private Camera _mainCamera;
        private UnitState _lastUnit;
        private NavMeshAgent _navMeshAgent;
        private SelectedService _selectedService;

        #endregion


        #region Constructor

        [Inject]
        private void Construct(SelectedService selectedService)
        {
            _selectedService = selectedService;
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
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _interactiveObjects))
            {
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();

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
                        _frameImage.enabled = false;
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        //Debug.Log("клик mouse2 по земле");
                        if (_selectedService.SelectedUnits != null)
                        {
                            if (_selectedService.SelectedUnits.Count == 1)
                            {
                                ForwardUnit(hit);
                            }

                            else
                            {
                                ForwardUnits(hit);
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
            Debug.Log("курсор попал по юниту");
            var unit = hit.collider.GetComponent<UnitState>();
            unit.OnHoverEnter();
            _lastUnit = unit;
        }

        private void SelectThisUnit(RaycastHit hit)
        {
            Debug.Log("клип попал по юниту");
            _selectedService.DeselectAllUnits();
            _selectedService.SelectUnit(hit.collider.gameObject);
        }

        private void IlluminationUnitTurnOff()
        {
            Debug.Log("юнит вышел из под луча");
            _lastUnit.OnHoverExit();
            _lastUnit = null;
        }

        private void DeselectAllUnits()
        {
            Debug.Log("клип mouse1 по земле отменяет выделение юнитам");
            _selectedService.DeselectAllUnits();

            _frameStartPosition = Input.mousePosition;
        }

        private void CreateSelectionFrame()
        {
            _frameFinishPosition = Input.mousePosition;

            Vector2 min = Vector2.Min(_frameStartPosition, _frameFinishPosition);
            Vector2 max = Vector2.Max(_frameStartPosition, _frameFinishPosition);
            Vector2 size = max - min;
            if (size.magnitude > 10)
            {
                _frameImage.enabled = true;
                _frameImage.rectTransform.anchoredPosition = min;
                _frameImage.rectTransform.sizeDelta = size;

                Rect rect = new Rect(min, size);

                //SelectedService.Instance.DeselectAllUnits();

                for (int i = 0; i < _selectedService.AllUnits.Count; i++)
                {
                    var unitObject = _selectedService.AllUnits[i];
                    bool isUnitSelected = _selectedService.IsUnitSelected(unitObject);
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
            Debug.Log("один юнит отправляется в точку");
            foreach (var unit in _selectedService.SelectedUnits)
            {
                _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                _navMeshAgent.SetDestination(hit.point);
            }
        }

        private void ForwardUnits(RaycastHit hit)
        {
            
            float sumX = 0f;
            float sumY = 0f;
            float sumZ = 0f;
            foreach (var unit in _selectedService.SelectedUnits)
            {
                sumX += unit.transform.position.x;
                sumY += unit.transform.position.y;
                sumZ += unit.transform.position.z;
            }

            float centrX = sumX / _selectedService.SelectedUnits.Count;
            float centrY = sumY / _selectedService.SelectedUnits.Count;
            float centrZ = sumZ / _selectedService.SelectedUnits.Count;

            Vector3 centralPoint = new Vector3(centrX, centrY, centrZ);

            float distanceToTheTarget = Vector3.Distance(centralPoint, hit.point);

            float groupRadius = 0;

            foreach (var unit in _selectedService.SelectedUnits)
            {
                if (groupRadius < Vector3.Distance(centralPoint, unit.transform.position))
                {
                    groupRadius = Vector3.Distance(centralPoint, unit.transform.position);
                }
            }
            
            Debug.Log($"радиус группы - {groupRadius}, дистанция до цели - {distanceToTheTarget}," +
                $" координаты центральной точки - {centralPoint}");

            if (groupRadius > distanceToTheTarget)
            {
                Debug.Log("юниты кучкуются");
                
                foreach (var unit in _selectedService.SelectedUnits)
                {
                    Vector3 difference = centralPoint - unit.transform.position;
                    Vector3 currentUnitTargetPoint = hit.point - difference / 2;

                    _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                    _navMeshAgent.SetDestination(currentUnitTargetPoint);
                }
            }
            else
            {
                Debug.Log("много юнитов отправляются в точку");
                
                foreach (var unit in _selectedService.SelectedUnits)
                {
                    Vector3 difference = centralPoint - unit.transform.position;
                    Vector3 currentUnitTargetPoint = hit.point - difference;

                    _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                    _navMeshAgent.SetDestination(currentUnitTargetPoint);
                }
            }
        }

        #endregion
    }
}