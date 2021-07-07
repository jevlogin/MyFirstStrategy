using Abstractions;
using UnityEngine;
using Utils;


namespace InputSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;

        [InjectAsset("Ellen")] private GameObject _unitPrefab;
    }
}