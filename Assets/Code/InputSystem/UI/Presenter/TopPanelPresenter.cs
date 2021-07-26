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
        [SerializeField] private GameObject _menu;

        [Inject] private ITimeModel _timeModel;

        private void Awake()
        {
            _view.MenuButtonClick.Subscribe(_ => HandleMenuButtonClick());
            _timeModel.GameTime.Subscribe(time => _view.TimeFormatted = TimeSpan.FromSeconds(time).ToString());
        }


        private void HandleMenuButtonClick()
        {
            //  пока с меню
            Debug.Log($"ShowMenu");
            _menu.SetActive(true);
            _timeModel.Pause();
        }
    }
}