using System.Collections.Generic;
using Split.Game.Units;
using Split.Infrastructure.GameOver;
using Split.Infrastructure.Pause;

namespace Split.Infrastructure.UnitRegisterService
{
    public class UnitRegisterService : IUnitRegisterService
    {
        private IGameOverService _gameOver;
        private IPauseService _pauseService;
        private List<RegisterUnits> _units = new();

        public UnitRegisterService(IGameOverService gameOver,IPauseService pauseService)
        {
            _gameOver = gameOver;
            _pauseService = pauseService;
        }

        public void Init()
        {
        }

        public void Register(RegisterUnits unitRegister)
        {
            _units.Add(unitRegister);
        }

        public void Unregister(RegisterUnits unitRegister)
        {
            _units.Remove(unitRegister);
            if (_units.Count == 0)
            {
                //OnAllDead?.Invoke();
                _gameOver.ActivateGameOver(true);
                _pauseService.IsPauseActive = false;
            }
        }

        public void Dispose()
        {
            _units = null;
        }
    }
}