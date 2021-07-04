using Abstractions;
using UnityEngine;


namespace Core
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
    {
        #region ICommandExecutor

        public void Execute(ICommand command)
        {
            ExecuteSpecificCommand((T)command);
        }

        #endregion


        #region Properties

        protected abstract void ExecuteSpecificCommand(T command); 

        #endregion
    }
}