using Split.Game.Units.SelectedFolder;
using UnityEngine;
using Zenject;

namespace Split.Game.Units
{
    [RequireComponent(typeof(Outline))]
    public class UnitState : MonoBehaviour
    {
        public bool IsUnderTheCursor;
        public bool IsSelected;
        [SerializeField] private float _widthOutlineOnHover = 1;
        [SerializeField] private float _widthOutlineOnSelected = 3;
        private Outline _outline;
        private SelectedService _selectedService;

        [Inject]
        public void Construct(SelectedService selectedService)
        {
            _selectedService = selectedService;
        }
        private void OnEnable()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineWidth = 0;
        }

        private void Start()
        { 
            _selectedService.AddUnit(gameObject);
        }

        public void OnHoverEnter()
        {
            if (IsSelected)
                return;

            _outline.OutlineWidth = _widthOutlineOnHover;
            IsUnderTheCursor = true;
        }

        public void OnHoverExit()
        {
            if (IsSelected)
                return;

            _outline.OutlineWidth = 0;
            IsUnderTheCursor = false;
        }

        public void OnSelected()
        {
            _outline.OutlineWidth = _widthOutlineOnSelected;
            IsSelected = true;
        }

        public void OnSelectedExit()
        {
            _outline.OutlineWidth = 0;
            IsSelected = false;
        }
    }
}