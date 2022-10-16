using System;
using Split.Game.Units.SelectedFolder;
using UnityEngine;
namespace Split.Game.Units
{
    public class UnitMovement : MonoBehaviour
    {
       // [SerializeField] private Transform _target;
        
        [Range(0,10)]
        [SerializeField] private float _speed;
        
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            SelectedService.Instance.AddUnit(gameObject);
        }

        private void Update()
        {
           // _transform.position = Vector3.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            SelectedService.Instance.SelectUnit(gameObject);
        }
    }
}
