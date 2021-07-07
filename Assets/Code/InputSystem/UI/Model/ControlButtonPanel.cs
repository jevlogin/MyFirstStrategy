using Abstractions;
using System;
using Zenject;


namespace Model
{
    public sealed class ControlButtonPanel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;

        [Inject] private CommandCreator<IProduceUnitCommand> _produceCreator;
        [Inject] private CommandCreator<IAttackCommand> _attackCreator;
        [Inject] private CommandCreator<IMoveCommand> _moveCreator;
        [Inject] private CommandCreator<IStopCommand> _stopCreator;
        [Inject] private CommandCreator<IPatroulCommand> _patroulCreator;

        private bool _commandIsPending;

        public void HandlerClick(ICommandExecutor executor)
        {
            if (_commandIsPending)
            {
                ProcessOnCancel();
                OnCommandAccepted?.Invoke(executor);
            }

            _commandIsPending = false;
            OnCommandSent?.Invoke();

            _produceCreator.CreateCommand(executor, command => executor.Execute(command));
            _attackCreator.CreateCommand(executor, command => executor.Execute(command));
            _moveCreator.CreateCommand(executor, command => executor.Execute(command));
            _stopCreator.CreateCommand(executor, command => executor.Execute(command));
            _patroulCreator.CreateCommand(executor, command => executor.Execute(command));
        }

        public void OnSelectionChanged()
        {
            _commandIsPending = false;
            ProcessOnCancel();
        }

        private void ProcessOnCancel()
        {
            _produceCreator.ProcessCancel();
            _attackCreator.ProcessCancel();
            _moveCreator.ProcessCancel();
            _stopCreator.ProcessCancel();
            _patroulCreator.ProcessCancel();

            OnCommandCancel?.Invoke();
        }
    }
}