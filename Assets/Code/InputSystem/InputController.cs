using UnityEngine;
using Abstractions;
using Model;
using Zenject;
using UnityEngine.EventSystems;


namespace InputSystem
{
    public sealed class InputController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private SelectedItemModel _currentSelected;

        [Inject] private GroundClickModel _currentGroundClickModel;

        private Camera _camera;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _camera = Camera.main;
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
                            _currentSelected.SetValue(selectableItem);
                        }
                        _currentGroundClickModel.SetValue(hitInfo.point);
                    }
                }
            }
        }

        #endregion
    }
}