namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// Defines an event for producing units.
    /// </summary>
    public interface IUnitProducer
    {
        event UnitProducedEventHandler OnUnitProduced;
    }
}
