using Abstractions;
using Core;
using Model;
using UnityEngine;
using UnityEngine.AI;


namespace CommandExecutors
{
    public sealed class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        #region Fields

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopUnitMovement _stop;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _stop = GetComponent<StopUnitMovement>();
        } 

        #endregion


        #region Methods

        protected override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            _navMeshAgent.SetDestination(command.To);
            _animator.SetTrigger("Walk");
            await _stop;
            _animator.SetTrigger("Idle");
        }

        #endregion
    }
}