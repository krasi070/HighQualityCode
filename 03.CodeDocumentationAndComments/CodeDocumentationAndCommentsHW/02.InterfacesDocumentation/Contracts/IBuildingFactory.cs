namespace Empires.Contracts
{
    /// <summary>
    /// Defines a method for creating a building.
    /// </summary>
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}
