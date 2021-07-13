using Abstractions;
using UnityEngine;


namespace Model
{
    internal class AttackUnitCommand : IAttackCommand
    {
        #region Fields

        private IAttackable _target;

        #endregion


        #region Properties

        public IAttackable Target => _target;

        #endregion


        #region ClassLifeCycles

        public AttackUnitCommand(IAttackable paramResult)
        {
            _target = paramResult;
        }

        #endregion
    }
}