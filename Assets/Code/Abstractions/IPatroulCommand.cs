using UnityEngine;


namespace Abstractions
{
    public interface IPatroulCommand : ICommand
    {
        Vector3 From { get; }
        Vector3 To { get; }
    }
}