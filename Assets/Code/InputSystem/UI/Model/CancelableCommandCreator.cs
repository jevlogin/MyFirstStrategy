using Abstractions;
using System;
using System.Threading;
using UnityEngine;
using Utils;
using Zenject;


namespace Model
{
    public abstract class CancelableCommandCreator<T, TParam> : CommandCreator<T> where T : ICommand
    {
        #region Fields

        [Inject] private IAwaitable<TParam> _param;
        private CancellationTokenSource _tokenSource;

        #endregion


        #region Methods

        protected override async void CreateSpecificCommand(Action<T> onCreate)
        {
            _tokenSource = new CancellationTokenSource();

            try
            {
                var paramResult = await _param.AsTask().WithCancelation(_tokenSource.Token);
                onCreate?.Invoke(GetCommandT(paramResult));
            }
            catch (OperationCanceledException e)
            {
                Debug.Log($"{nameof(e)} - {e}");
            }
        }

        protected abstract T GetCommandT(TParam paramResult);

        public override void CancelCommand()
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
                _tokenSource.Dispose();
                _tokenSource = null;
            }
        }

        #endregion
    }
}