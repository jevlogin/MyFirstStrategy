using UnityEngine;
using Model;
using View;
using Abstractions;


namespace Presenter
{
    public sealed class SelectedItemPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemView _view;
        [SerializeField] private SelectedItemModel _model;

        private void Start()
        {
            UpdateView(_model.Value);
            _model.OnUpdated += UpdateView;
        }

        private void OnDestroy()
        {
            _model.OnUpdated -= UpdateView;
        }

        private void UpdateView(ISelectableItem obj)
        {
            if (_model.Value == null)
            {
                _view.gameObject.SetActive(false);
                return;
            }

            _view.gameObject.SetActive(true);
            _view.Icon = _model.Value.Icon;
            _view.Name = _model.Value.Name;
            _view.Health = $"{_model.Value.Health} / {_model.Value.MaxHealth}";
            _view.HealthBar = _model.Value.Health / _model.Value.MaxHealth;
        }
    }
}