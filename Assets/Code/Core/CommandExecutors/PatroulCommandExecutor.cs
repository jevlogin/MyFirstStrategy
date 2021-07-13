using Abstractions;
using Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


namespace CommandExecutors
{
    public sealed class PatroulCommandExecutor : CommandExecutorBase<IPatroulCommand>
    {
        #region Fields

        [SerializeField] private NavMeshAgent _navMeshAgent;
        private float _minSqrStoppingDistance;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _minSqrStoppingDistance = _navMeshAgent.stoppingDistance * _navMeshAgent.stoppingDistance;
        }

        #endregion

        protected override void ExecuteSpecificCommand(IPatroulCommand command)
        {
            Patroul(command.From, command.To);
        }

        private async void Patroul(Vector3 from, Vector3 to)
        {
            while (true)
            {
                await MoveTo(to);
                await MoveTo(from); 
            }
        }

        private async Task MoveTo(Vector3 to)
        {
            _navMeshAgent.SetDestination(to);
            while ((transform.position - to).sqrMagnitude >= _minSqrStoppingDistance)
            {
                await Task.Yield();
            }
        }
    }
}