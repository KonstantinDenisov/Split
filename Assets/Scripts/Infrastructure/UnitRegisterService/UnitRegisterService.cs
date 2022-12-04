using System.Collections.Generic;
using Split.Game.Units;
using Split.Infrastructure.GameOver;

namespace Split.Infrastructure.UnitRegisterService
{
    public class UnitRegisterService : IUnitRegisterService
    {
        private IGameOverService _gameOver;
        private List<RegisterUnits> _units = new();

        public UnitRegisterService(IGameOverService gameOver)
        {
            _gameOver = gameOver;
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
                _gameOver.ActivateGameOver(true);
            }
        }

        public void Dispose()
        {
            _units = null;
        }
    }
}