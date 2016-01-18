namespace Empires.Contracts
{
    /// <summary>
    /// Defines a method for creating a unit.
    /// </summary>
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
