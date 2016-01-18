namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// Defines a method for creating resources.
    /// </summary>
    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
