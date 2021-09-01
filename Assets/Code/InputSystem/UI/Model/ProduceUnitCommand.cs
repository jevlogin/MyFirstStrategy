using Abstractions;
using UnityEngine;
using Utils;
using Zenject;


namespace InputSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;

        [Inject (Id = "EllenProductionTime")] public int ProductionTime { get; }
        [Inject(Id = "EllenUnitName")] public string UnitName { get; }
        
        //[Inject(Id = "EllenUnitIcon")] 
        public Sprite UnitIcon { get; }

        [InjectAsset("Ellen")] private GameObject _unitPrefab;
    }
}