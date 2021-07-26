using Abstractions;
using UnityEngine;
using View;
using Zenject;
using UniRx;


namespace Presenter
{
    public sealed class MenuViewPresenter : MonoBehaviour
    {
        [SerializeField] private MenuView _view;
        [Inject] private ITimeModel _timeModel;

        private void Awake()
        {
            _view.ContinueButtonClick.Subscribe(unit => HandleContinueButton());
        }

        private void HandleContinueButton()
        {
            gameObject.SetActive(false);
            _timeModel.UnPause();
        }
    }
}