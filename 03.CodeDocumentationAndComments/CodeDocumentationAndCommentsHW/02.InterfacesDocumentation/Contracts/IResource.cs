namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// Represents a resource. Contains getters for type and quantity.
    /// </summary>
    public interface IResource
    {
        ResourceType ResourceType { get; }

        int Quantity { get; }
    }
}
