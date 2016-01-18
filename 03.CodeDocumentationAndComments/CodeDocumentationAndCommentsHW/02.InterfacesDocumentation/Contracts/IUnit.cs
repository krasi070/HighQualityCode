namespace Empires.Contracts
{
    /// <summary>
    /// Represents a unit. Contains getters for health and attack damage and a setter for health.
    /// </summary>
    public interface IUnit : IAttacker, IDestroyable
    {
    }
}
