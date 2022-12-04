using Split.Game.Units;

namespace Split.Infrastructure.UnitRegisterService
{
    public interface IUnitRegisterService
    {
        void Register(RegisterUnits unitRegister);
        void Unregister(RegisterUnits units);
    }
}