using UnityEngine;


namespace Abstractions
{
    public interface IAttackCommand : ICommand
    {
        IAttackable Target { get; }
    }
}