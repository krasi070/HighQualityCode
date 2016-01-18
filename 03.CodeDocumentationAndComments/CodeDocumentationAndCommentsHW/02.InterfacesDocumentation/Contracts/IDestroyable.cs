namespace Empires.Contracts
{
    /// <summary>
    /// Defines a getter and a setter for health.
    /// </summary>
    public interface IDestroyable
    {
        // Added public setter
        int Health { get; set; }
    }
}
