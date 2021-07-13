using Abstractions;
using UnityEngine;


namespace Model
{
    public sealed class PatroulUnitCommand : IPatroulCommand
    {
        #region Fields

        private Vector3 _to;
        private Vector3 _from;

        #endregion


        #region Properties

        public Vector3 From => _from;
        public Vector3 To => _to;

        #endregion


        #region ClassLifeCycles

        public PatroulUnitCommand(Vector3 from, Vector3 to)
        {
            _from = from;
            _to = to;
        }

        #endregion
    }
}