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
        [Inject] private DiContainer _container;

        #endregion


        #region Methods

        protected override void CreateSpecificCommand(Action<IProduceUnitCommand> onCreate)
        {
            var command = new ProduceUnitCommand();
            _container.Inject(command);
            onCreate?.Invoke(_assets.Inject(command));
        }

        public override void CancelCommand()
        {
            //Debug.Log($"{nameof(ProduceUnitCommandCreator)} - ProcessCancel");
        }

        #endregion
    }
}