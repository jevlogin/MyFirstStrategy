using Abstractions;
using System;
using UniRx;
using UnityEngine;


namespace Core
{
    internal sealed class ProductionTask : IProductionTask
    {
        #region Fields

        public int ProductionTime { get; }
        public Sprite UnitIcon { get; }
        public string UnitName { get; }
        public GameObject UnitPrefab { get; }

        private readonly ReactiveProperty<float> _productionTimeLeft = new ReactiveProperty<float>();

        #endregion


        #region Properties

        public IObservable<int> ProductionTimeLeft => _productionTimeLeft.Select(value => (int)value);

        #endregion


        #region ClassLifeCycles

        public ProductionTask(int productionTime, Sprite unitIcon, string unitName, GameObject unitPrefab)
        {
            ProductionTime = productionTime;
            _productionTimeLeft.Value = productionTime;
            UnitIcon = unitIcon;
            UnitName = unitName;
            UnitPrefab = unitPrefab;
        }

        #endregion


        #region Methods

        public void Tick(float deltaTime)
        {
            _productionTimeLeft.Value -= Math.Min(deltaTime, _productionTimeLeft.Value);
        }

        public bool IsEnded() => _productionTimeLeft.Value <= 0.0f;

        public float Debug_GetProductionTimeLeft()
        {
            return _productionTimeLeft.Value;
        }

        #endregion
    }
}