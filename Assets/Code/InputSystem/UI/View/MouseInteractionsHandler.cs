using Abstractions;
using Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    internal sealed class MouseInteractionsHandler : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private SelectedItemModel _selectableValue;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
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
                .Select(hit => hit.collider.GetComponentInParent<IUnitProducer>())
                .Where(c => c != null)
                .FirstOrDefault();
            if (mainBuilding == default)
            {
                return;
            }
            mainBuilding.ProduceUnit();
        }
    }
}