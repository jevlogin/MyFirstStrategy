using Abstractions;
using Model;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


namespace View
{
    internal sealed class MouseInteractionsHandler : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SelectedItemModel _selectableValue;
        [SerializeField] private EventSystem _eventSystem;

        private Camera _camera;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            //TODO IsPointerOverGameObject - не работает!!!
            if (_eventSystem.IsPointerOverGameObject())
            {
                if (!Input.GetButtonUp("Fire1"))
                {
                    return;
                }

                var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
                if (hits.Length == 0)
                {
                    return;
                }
                var mainBuilding = hits
                    .Select(hit => hit.collider.GetComponentInParent<IProduceUnitCommand>())
                    .Where(c => c != null)
                    .FirstOrDefault();
                if (mainBuilding == default)
                {
                    return;
                }
            }
        }

        #endregion
    }
}