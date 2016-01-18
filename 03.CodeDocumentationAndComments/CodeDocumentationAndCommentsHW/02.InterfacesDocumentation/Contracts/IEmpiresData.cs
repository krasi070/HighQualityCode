namespace Empires.Contracts
{
    using System.Collections.Generic;
    using Enums;

    /// <summary>
    /// Defines methods for adding buildings and units and contains getters for buildings, units and resources.
    /// </summary>
    public interface IEmpiresData
    {
        IEnumerable<IBuilding> Buildings { get; }

        void AddBuilding(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUnit(IUnit unit);

        IDictionary<ResourceType, int> Resources { get; } 
    }
}
