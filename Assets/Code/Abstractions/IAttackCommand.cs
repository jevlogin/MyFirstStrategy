using UnityEngine;


namespace Abstractions
{
    public interface IAttackCommand : ICommand
    {
        GameObject Target { get; }
    }
}