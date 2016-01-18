namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// Defines an event for producing resources.
    /// </summary>
    public interface IResourceProducer
    {
        event ResourceProducedEventHandler OnResourceProduced;
    }
}
