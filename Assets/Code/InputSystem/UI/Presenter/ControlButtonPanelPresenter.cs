using Abstractions;
using Model;
using System.Linq;
using UnityEngine;
using View;
using Zenject;


namespace Presenter
{
    public sealed class ControlButtonPanelPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _selectedItemModel;
        [SerializeField] private ControlButtonPanelView _view;

        [Inject] private ControlButtonPanel _model;

        private ISelectableItem _currentSelectableItem;

        private void Start()
        {
            _view.OnClick += ClickHandler;

            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteraction;

            _selectedItemModel.OnUpdated += SetButton;
        }

        private void OnDestroy()
        {
            _selectedItemModel.OnUpdated -= SetButton;
            _view.OnClick -= ClickHandler;
            _model.OnCommandSent -= _view.UnblockAllInteractions;
            _model.OnCommandCancel -= _view.UnblockAllInteractions;
            _model.OnCommandAccepted -= _view.BlockInteraction;
        }

        private void ClickHandler(ICommandExecutor executor)
        {
            _model.HandlerClick(executor);
        }

        private void SetButton(ISelectableItem selectable)
        {
            if (_currentSelectableItem == selectable)
            {
                return;
            }

            if (_currentSelectableItem != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelectableItem = selectable;

            _view.ClearButtons();

            if (selectable != null)
            {
                var executors = (_selectedItemModel.Value as Component)?.GetComponents<ICommandExecutor>().ToList();
                _view.SetButtons(executors);
            }
        }
    }
}