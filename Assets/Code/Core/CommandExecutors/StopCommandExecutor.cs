using Abstractions;
using Core;
using System.Threading.Tasks;
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

        //  Не знаю, насколько это верное удержание позиции, но игрок останавливается )
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            Stop(command);
        }

        private async void Stop(IStopCommand command)
        {
            await StopTask(transform.position);
        }

        private async Task StopTask(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
            await Task.Yield();
        }

        #endregion
    }
}