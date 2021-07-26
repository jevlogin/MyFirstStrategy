using UnityEngine;
using Model;
using View;
using Abstractions;
using UniRx;
using System;

namespace Presenter
{
    public sealed class SelectedItemPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemView _view;
        [SerializeField] private SelectedItemModel _model;

        private IDisposable _healthUpdater;

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
            if (_healthUpdater != null)
            {
                _healthUpdater.Dispose();
                _healthUpdater = null;
            }

            if (_model.Value == null)
            {
                _view.gameObject.SetActive(false);
                return;
            }

            _view.gameObject.SetActive(true);
            _view.Icon = _model.Value.Icon;
            _view.Name = _model.Value.Name;

            _healthUpdater = _model.Value.Health.Subscribe(currentHealth =>
            {
                _view.HealthBar = currentHealth / _model.Value.MaxHealth;
                _view.Health = $"{currentHealth} / {_model.Value.MaxHealth}";
            });
        }
    }
}