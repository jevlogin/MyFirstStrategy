using UnityEngine;
using Abstractions;
using Core;
using UniRx;
using Zenject;
using System.Linq;


namespace CommandExecutors
{
    public sealed class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitCommand>, ITickable
    {
        private ReactiveCollection<ProductionTask> ProductionQueue = new ReactiveCollection<ProductionTask>();

        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            //Debug.Log($"Execute Produce Unit Command");

            var newTask = new ProductionTask(command.ProductionTime, command.UnitIcon, command.UnitName, command.UnitPrefab);
            Debug.Log($"{newTask.Debug_GetProductionTimeLeft()}");

            ProductionQueue.Add(newTask);
        }

        private void CreateUnit(ProductionTask task)
        {
            ProductionQueue.Remove(task);
            Instantiate(task.UnitPrefab, transform.position + Vector3.forward * 2, Quaternion.identity);
        }

        public void Tick()
        {
            if (ProductionQueue.Count == 0)
            {
                return;
            }

            var currentTask = ProductionQueue.First();

            if (currentTask.IsEnded())
            {
                CreateUnit(currentTask);
            }
            else
            {
                //TODO - Почему игрок создается раньше чем время доходит до конца?!
                currentTask.Tick(Time.deltaTime);
                Debug.Log($"{currentTask.Debug_GetProductionTimeLeft()}");
            }
        }
    }
}