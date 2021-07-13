using Abstractions;
using System;
using UnityEngine;


namespace Model
{
    public abstract class ScriptableObjectContainerBase<T> : ScriptableObject, IAwaitable<T>
    {
        #region Fields

        public event Action<T> OnUpdated;
        private T _value;

        #endregion


        #region Properties

        public T Value => _value;

        #endregion


        #region Methods

        public void SetValue(T value)
        {
            _value = value;
            OnUpdated?.Invoke(_value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new ValueChangedNotifier(this);
        }

        private class ValueChangedNotifier : IAwaiter<T>
        {
            private Action _continuation;
            private T _result;
            private bool _isCompleted;
            private readonly ScriptableObjectContainerBase<T> _valueContainer;
            public ValueChangedNotifier(ScriptableObjectContainerBase<T> valueContainer)
            {
                _valueContainer = valueContainer;
                _valueContainer.OnUpdated += HandleValueChanged;
            }

            public bool IsCompleted => _isCompleted;

            public T GetResult()
            {
                return _result;
            }

            public void OnCompleted(Action continuation)
            {
                _continuation = continuation;
                if (IsCompleted)
                {
                    _continuation?.Invoke();
                }
            }

            private void HandleValueChanged(T value)
            {
                _valueContainer.OnUpdated -= HandleValueChanged;
                _isCompleted = true;
                _result = _valueContainer.Value;
                _continuation?.Invoke();
            }
        }

        #endregion
    }
}