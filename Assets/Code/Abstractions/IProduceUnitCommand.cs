using UnityEngine;


namespace Abstractions
{
    public interface IProduceUnitCommand : ICommand
    {
        int ProductionTime { get; }
        Sprite UnitIcon { get; }
        string UnitName { get; }
        GameObject UnitPrefab { get; }
    }
}