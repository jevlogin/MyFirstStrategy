namespace Abstractions
{
    public interface ICommandExecutor
    {
        void Execute(ICommand command);
    }
}