namespace Abstractions
{
    public interface IAwaitable<TResult>
    {
        IAwaiter<TResult> GetAwaiter();
    }
}