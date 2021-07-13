using Abstractions;
using InputSystem;
using System;
using UnityEngine;
using Utils;
using Zenject;


namespace Model
{
    public sealed class ProduceUnitCommandCreator : CommandCreator<IProduceUnitCommand>
    {
        #region Fields

        [Inject] private AssetStorage _assets;

        #endregion


        #region Methods

        protected override void CreateSpecificCommand(Action<IProduceUnitCommand> onCreate)
        {
            onCreate?.Invoke(_assets.Inject(new ProduceUnitCommand()));
        }

        public override void CancelCommand()
        {
            //Debug.Log($"{nameof(ProduceUnitCommandCreator)} - ProcessCancel");
        }

        #endregion
    }
}