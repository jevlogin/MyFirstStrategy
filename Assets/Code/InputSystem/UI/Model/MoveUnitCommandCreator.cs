using Abstractions;
using InputSystem;
using System;
using UnityEngine;
using Zenject;


namespace Model
{
    public sealed class MoveUnitCommandCreator : CommandCreator<IMoveCommand>
    {
        private Action<IMoveCommand> _onCreate;
        private GroundClickModel _currentGroundClickModel;

        [Inject]
        public MoveUnitCommandCreator(GroundClickModel groundClickModel)
        {
            _currentGroundClickModel = groundClickModel;
            _currentGroundClickModel.OnUpdated += HandleGroundClick;
        }

        ~MoveUnitCommandCreator()
        {
            _currentGroundClickModel.OnUpdated -= HandleGroundClick;
        }

        private void HandleGroundClick()
        {
            _onCreate?.Invoke(new MoveUnitCommand(_currentGroundClickModel.Value));
            _onCreate = null;
        }

        protected override void CreateSpecificCommand(Action<IMoveCommand> onCreate)
        {
            _onCreate = onCreate;
        }

        public override void ProcessCancel()
        {
            Debug.Log($"{nameof(MoveUnitCommandCreator)} - ProcessCancel");
            _onCreate = null;
        }
    }
}