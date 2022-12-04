using Split.Infrastructure.UnitRegisterService;
using UnityEngine;
using Zenject;

namespace Split.Game.Units
{
    public class RegisterUnits: MonoBehaviour
    {
        private IUnitRegisterService _unitRegisterService;

        [Inject]
        public void Construct(IUnitRegisterService unitRegisterService)
        {
            _unitRegisterService =  unitRegisterService;
        }

        private void Start()
        {
            _unitRegisterService.Register(this);
        }

        private void OnDestroy()
        {
            _unitRegisterService.Unregister(this);
        }

    }
}