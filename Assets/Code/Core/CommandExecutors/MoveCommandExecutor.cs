using Abstractions;
using Core;
using UnityEngine;
using UnityEngine.AI;


namespace CommandExecutors
{
    public sealed class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        #region Fields

        [SerializeField] private NavMeshAgent _navMeshAgent;

        #endregion


        #region Methods

        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            _navMeshAgent.SetDestination(command.To);
            Debug.Log($"{name} is moving!");
        }

        #endregion
    }
}