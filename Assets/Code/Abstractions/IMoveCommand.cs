using UnityEngine;

namespace Abstractions
{
    public interface IMoveCommand : ICommand
    {
        Vector3 To { get; }
    }
}