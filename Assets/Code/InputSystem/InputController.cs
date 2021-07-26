using UnityEngine;
using Abstractions;
using Model;
using Zenject;
using UnityEngine.EventSystems;
using System.Linq;

namespace InputSystem
{
    public sealed class InputController : MonoBehaviour
    {
        #region Fields

        [Inject] private AttackableTargetModel _attackable;

        [Inject] private SelectedItemModel _currentSelected;
        [Inject] private GroundClickModel _currentGroundClickModel;

        private EventSystem _eventSystem;
        private Camera _camera;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _camera = Camera.main;
            _eventSystem = EventSystem.current;
        }

        private void Update()
        {
            if (!_eventSystem.IsPointerOverGameObject())
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                    {
                        if (hitInfo.collider.TryGetComponent<ISelectableItem>(out var selectableItem))
                        {
                            if (_currentSelected.Value != null || _currentSelected.Value != default)
                            {
                                if (!_currentSelected.Value.Equals(selectableItem))
                                {
                                    _currentSelected.SetValue(selectableItem);
                                }
                            }
                            else
                            {
                                _currentSelected.SetValue(selectableItem);
                            }
                        }
                        else
                        {
                            if (hitInfo.collider.TryGetComponent<IAttackable>(out var attackable))
                            {
                                _attackable.SetValue(attackable);
                            }
                            else
                            {
                                _currentGroundClickModel.SetValue(hitInfo.point);
                                _currentSelected.SetValue(null);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}