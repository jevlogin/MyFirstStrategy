using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Abstractions;
using Core;
using System.Linq;


namespace View
{
    public sealed class ControlButtonPanelView : MonoBehaviour
    {
        #region Fields

        public event Action<ICommandExecutor> OnClick;

        [SerializeField] private Button _produceUnit;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _patroulButton;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _stopButton;

        private Dictionary<Type, Button> _executorsToButtonList = new Dictionary<Type, Button>();

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _executorsToButtonList = new Dictionary<Type, Button>
            {
                {typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnit },
                {typeof(CommandExecutorBase<IMoveCommand>), _moveButton },
                {typeof(CommandExecutorBase<IPatroulCommand>), _patroulButton },
                {typeof(CommandExecutorBase<IAttackCommand>), _attackButton },
                {typeof(CommandExecutorBase<IStopCommand>), _stopButton },
            };
            ClearButtons();
        }

        #endregion


        #region Methods

        public void SetButtons(List<ICommandExecutor> executors)
        {
            foreach (var executor in executors)
            {
                var button = _executorsToButtonList.FirstOrDefault(kvp => kvp.Key.IsInstanceOfType(executor)).Value;
                if (button == null)
                {
                    Debug.LogError($"Executor is not supported");
                    continue;
                }

                button.gameObject.SetActive(true);
                button.onClick.AddListener(() => OnClick?.Invoke(executor));
            }
        }

        public void UnblockAllInteractions()
        {
            //Debug.Log($"{name} - ControlButtonPanelView - UnblocAllInteractions");
            SetInteractable(true);
        }

        private void SetInteractable(bool value)
        {
            foreach (var button in _executorsToButtonList.Values)
            {
                button.interactable = true;
            }
        }

        public void BlockInteraction(ICommandExecutor executor)
        {
            //Debug.Log($"BlockInteraction");
            UnblockAllInteractions();
            var button = GetButtonGameObjectByType(executor.GetType());
            button.interactable = false;
            button.gameObject.SetActive(false);
        }

        private Button GetButtonGameObjectByType(Type type)
        {
            return _executorsToButtonList
                .Where(t => t.Key.IsAssignableFrom(type))
                .First()
                .Value;
        }

        public void ClearButtons()
        {
            foreach (var buttton in _executorsToButtonList.Values)
            {
                buttton.onClick.RemoveAllListeners();
                buttton.gameObject.SetActive(false);
            }
        }

        #endregion
    }
}