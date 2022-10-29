using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Split.Game.Units.SelectedFolder
{
    public class CameraRayCaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _unitLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _interactiveObjects;
        [SerializeField] private Image _frameImage;
        private Vector2 _frameStartPosition;
        private Vector2 _frameFinishPosition;
        private Camera _mainCamera;
        private UnitState _lastUnit;
        private NavMeshAgent _navMeshAgent;

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
                Debug.Log("луч попадает во что-то со слоями из маски");
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();

                if (interactiveObject == null)
                {
                    return;
                }
                Debug.Log("луч попадает в интерактивный объект");
                if (interactiveObject.InteractiveType == InteractiveType.Unit)
                {
                    Debug.Log("луч попадает в юнита");
                    if (_lastUnit == null)
                    {
                        Debug.Log("юнит попал под курсор");
                        var unit = hit.collider.GetComponent<UnitState>();
                        unit.OnHoverEnter();
                        _lastUnit = hit.collider.GetComponent<UnitState>();
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("юнит попал под клик");
                        SelectedService.Instance.SelectUnit(hit.collider.gameObject); 
                    }
                }

                if (interactiveObject.InteractiveType == InteractiveType.Ground)
                {
                    Debug.Log("луч попал по земле");
                    if (_lastUnit != null)
                    {
                        Debug.Log("юнит вышел из под луча");
                        _lastUnit.OnHoverExit();
                        _lastUnit = null;    
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("клип mouse1 по земле отменяет выделение юнитам");
                        SelectedService.Instance.DeselectAllUnits();

                        
                        _frameStartPosition = Input.mousePosition;
                    }

                    if (Input.GetMouseButton(0))
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
                        
                            SelectedService.Instance.DeselectAllUnits();
                        
                            for (int i = 0; i < SelectedService.Instance.AllUnits.Count; i++)
                            {
                                Vector2 screePosition =
                                    _mainCamera.WorldToScreenPoint(SelectedService.Instance.AllUnits[i].transform.position);
                                if (rect.Contains(screePosition))
                                {
                                    var unit = SelectedService.Instance.AllUnits[i].gameObject.GetComponent<UnitState>();
                                    unit.OnSelected();
                                }
                            }
                        }
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        _frameImage.enabled = false;
                    }

                    if (Input.GetMouseButtonDown(1))
                    {
                        Debug.Log("клик mouse2 по земле");
                        if (SelectedService.Instance.SelectedUnits != null)
                        {
                            foreach (var unit in SelectedService.Instance.SelectedUnits)
                            {
                                _navMeshAgent = unit.GetComponent<NavMeshAgent>();
                                _navMeshAgent.SetDestination(hit.point);
                            }  
                        }
                    }
                    
                }
            }
        }
    }
}