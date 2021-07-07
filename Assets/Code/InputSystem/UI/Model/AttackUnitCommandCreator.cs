using Abstractions;
using System;
using UnityEngine;

namespace Model
{
    public sealed class AttackUnitCommandCreator : CommandCreator<IAttackCommand>
    {
        public override void ProcessCancel()
        {
            Debug.Log($"{nameof(AttackUnitCommandCreator)} - ProcessCancel");

        }

        protected override void CreateSpecificCommand(Action<IAttackCommand> onCreate)
        {
            Debug.Log($"AttackUnitCommandCreator");
        }
    }
}