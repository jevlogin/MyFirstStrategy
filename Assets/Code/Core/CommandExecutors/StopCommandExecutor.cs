using Abstractions;
using Core;
using UnityEngine;
using UnityEngine.AI;


namespace CommandExecutors
{
    public sealed class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        #region Fields

        [SerializeField] private NavMeshAgent _navMeshAgent;

        #endregion


        #region Methods

        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            _navMeshAgent.SetDestination(transform.position);
            Debug.Log($"StopCommandExecutor");
        }

        #endregion
    }
}