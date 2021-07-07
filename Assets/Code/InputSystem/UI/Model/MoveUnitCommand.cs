using Abstractions;
using UnityEngine;


namespace InputSystem
{
    public sealed class MoveUnitCommand : IMoveCommand
    {
        #region Fields

        private Vector3 _value;

        #endregion


        #region Properties

        public Vector3 To => _value;

        #endregion


        #region ClassLifeCycles

        public MoveUnitCommand(Vector3 value)
        {
            _value = value;
        }

        #endregion
    }
}