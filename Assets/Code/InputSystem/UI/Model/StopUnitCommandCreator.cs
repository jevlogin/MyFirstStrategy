using Abstractions;
using System;
using UnityEngine;


namespace Model
{
    public sealed class StopUnitCommandCreator : CommandCreator<IStopCommand>
    {
        public override void CancelCommand()
        {
            //Debug.Log($"{nameof(StopUnitCommandCreator)} - ProcessCancel");
        }

        protected override void CreateSpecificCommand(Action<IStopCommand> onCreate)
        {
            onCreate?.Invoke(new StopUnitCommand());
        }
    }
}