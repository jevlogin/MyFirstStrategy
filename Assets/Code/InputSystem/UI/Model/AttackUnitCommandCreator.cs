using Abstractions;
using UnityEngine;


namespace Model
{
    public sealed class AttackUnitCommandCreator : CancelableCommandCreator<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand GetCommandT(IAttackable paramResult)
        {
            return new AttackUnitCommand(paramResult);
        }
    }
}