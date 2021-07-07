using Abstractions;
using Core;
using System;


namespace Model
{
    public abstract class CommandCreator<T> where T : ICommand
    {
        #region Methods

        public void CreateCommand(ICommandExecutor executor, Action<T> onCreate)
        {
            if (executor as CommandExecutorBase<T>)
            {
                CreateSpecificCommand(onCreate);
            }
        }

        protected abstract void CreateSpecificCommand(Action<T> onCreate);
        public abstract void ProcessCancel();

        #endregion
    }
}