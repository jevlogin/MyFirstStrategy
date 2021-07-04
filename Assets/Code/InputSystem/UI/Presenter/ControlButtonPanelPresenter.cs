using Abstractions;
using Utils;
using Model;
using System.Linq;
using UnityEngine;
using View;
using InputSystem;
using System.Collections.Generic;
using Core;
using System;

namespace Presenter
{
    public sealed class ControlButtonPanelPresenter : MonoBehaviour
    {
        [SerializeField] private ControlButtonPanelView _view;
        [SerializeField] private SelectedItemModel _model;

        [SerializeField] private AssetStorage _assets;

        private void Start()
        {
            _model.OnUpdated += SetButton;
            _view.OnClick += ClickHandler;
        }

        private void OnDestroy()
        {
            _model.OnUpdated -= SetButton;
            _view.OnClick -= ClickHandler;
        }

        private void ClickHandler(ICommandExecutor executor)
        {
            //TODO поправить создание комманд
            //executor.Execute(_assets.Inject(new ProduceUnitCommand()));

            //почему то € решил написать так...
            var unitProducer = executor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.Execute(_assets.Inject(new ProduceUnitCommandHeir()));
                return;
            }
            throw new ApplicationException($"{nameof(ControlButtonPanelPresenter)}.{nameof(ClickHandler)}: " +
                $"Unknow type of commands executor: {executor.GetType().FullName}!");
        }

        private void SetButton(ISelectableItem selectable)
        {
            _view.ClearButtons();

            var executors = (_model.Value as Component)?.GetComponents<ICommandExecutor>().ToList();
            _view.SetButtons(executors);

            /******/
            /*  ак?! почему этот код работает? */
            //var commandExecutors = new List<ICommandExecutor>();
            //commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            //_view.SetButtons(commandExecutors);
        }
    }
}