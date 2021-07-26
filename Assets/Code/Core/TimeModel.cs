using Abstractions;
using System;
using UniRx;
using UnityEngine;
using Zenject;


namespace Core
{
    public sealed class TimeModel : ITimeModel, ITickable
    {
        #region Fields
        
        public IObservable<int> GameTime => _gameTime.Select(value => (int)value);

        private readonly ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();
        private bool _isPaused; 

        #endregion

        public void Pause()
        {
            _isPaused = true;
            Time.timeScale = 0.0f;
        }

        public void Tick()
        {
            if (!_isPaused)
            {
                _gameTime.Value += Time.deltaTime; 
            }
        }

        public void UnPause()
        {
            _isPaused = false;
            Time.timeScale = 1.0f;
        }
    }
}