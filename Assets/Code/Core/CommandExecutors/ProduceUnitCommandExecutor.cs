using UnityEngine;
using Abstractions;
using Core;


namespace CommandExecutors
{
    public sealed class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>
    {
        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Debug.Log($"Execute Produce Unit Command");
        }
    }
}