using Abstractions;
using Core;
using UnityEngine;
using UnityEngine.AI;


namespace CommandExecutors
{
    public sealed class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        #region Fields

        private NavMeshAgent _navMeshAgent;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        #endregion


        #region Methods

        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("AttackCommandExecutor");
        }

        #endregion
    }
}