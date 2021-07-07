using Abstractions;
using Core;
using UnityEngine;


namespace CommandExecutors
{
    public sealed class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("AttackCommandExecutor");
        }
    }
}