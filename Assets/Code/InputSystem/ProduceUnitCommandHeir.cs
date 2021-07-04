using Abstractions;
using UnityEngine;
using Utils;


namespace InputSystem
{
    public sealed class ProduceUnitCommandHeir : ProduceUnitCommand, IProduceUnitCommand
    {
        [InjectAsset("Ellen")] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}