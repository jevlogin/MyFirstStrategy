using UnityEngine;
using Abstractions;
using Model;


namespace InputSystem
{
    public sealed class InputController : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private SelectedItemModel _currentSelected;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                {
                    if (hitInfo.collider.TryGetComponent<ISelectableItem>(out var selectableItem))
                    {
                        _currentSelected.SetValue(selectableItem);
                    }
                }
            }
        }
    }
}