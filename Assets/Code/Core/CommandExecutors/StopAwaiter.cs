using Abstractions;
using System;
using Void = Utils.AsyncUtils.Void;


namespace Model
{
    public sealed class StopAwaiter : IAwaiter<Void>
    {
        private readonly StopUnitMovement _stopUnitMovement;
        private Action _continuation;
        private bool _isCompleted;

        public StopAwaiter(StopUnitMovement stopUnitMovement)
        {
            _stopUnitMovement = stopUnitMovement;
        }

        public bool IsCompleted => _isCompleted;

        public Void GetResult()
        {
            return new Void();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                _continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }
    }
}