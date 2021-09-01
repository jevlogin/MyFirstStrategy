using Abstractions;
using System;
using UniRx;
using UnityEngine;
using View;
using Zenject;


namespace Presenter
{
    public sealed class TopPanelPresenter : MonoBehaviour
    {
        [SerializeField] private TopPanelView _view;
        [SerializeField] private GameObject _menuPauseToContinue;

        [Inject] private ITimeModel _timeModel;

        private void Awake()
        {
            _view.MenuButtonClick.Subscribe(_ => HandleMenuButtonClick());
            _timeModel.GameTime.Subscribe(time => _view.TimeFormatted = TimeSpan.FromSeconds(time).ToString()).AddTo(this);
        }


        private void HandleMenuButtonClick()
        {
            //  пока с меню
            Debug.Log($"ShowMenu");
            _menuPauseToContinue.SetActive(true);
            _timeModel.Pause();
        }
    }
}