using System.Runtime.CompilerServices;


namespace Abstractions
{
    public interface IAwaiter<TResult> : INotifyCompletion
    {
        bool IsCompleted { get; }
        TResult GetResult();
    }
}