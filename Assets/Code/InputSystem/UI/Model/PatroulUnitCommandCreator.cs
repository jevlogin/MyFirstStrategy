using Abstractions;
using System;
using UnityEngine;


namespace Model
{
    public sealed class PatroulUnitCommandCreator : CommandCreator<IPatroulCommand>
    {
        public override void ProcessCancel()
        {
            Debug.Log($"{nameof(StopUnitCommandCreator)} - ProcessCancel");
        }

        protected override void CreateSpecificCommand(Action<IPatroulCommand> onCreate)
        {
            Debug.Log($"PatroulUnitCommandCreator");
        }
    }
}