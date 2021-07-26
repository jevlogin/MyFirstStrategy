using System;


namespace Abstractions
{
    public interface IHealthHolder
    {
        IObservable<float> Health { get; }
        float MaxHealth { get; }
    }
}