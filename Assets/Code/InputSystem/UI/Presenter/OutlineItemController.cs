using Abstractions;
using Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Presenter
{
    public sealed class OutlineItemController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SelectedItemModel _model;
        [SerializeField] private Material _outLineMaterial;
        [SerializeField] private Material[] _oldMaterials;
        [SerializeField] private List<Material> _newMaterials;

        private ISelectableItem _value;

        #endregion


        #region ClassLifeCycles

        private void Awake()
        {
            _model.OnUpdated += UpdateOutline;
        }

        private void OnDestroy()
        {
            _model.OnUpdated -= UpdateOutline;
        }

        #endregion


        #region Methods

        private void UpdateOutline(ISelectableItem selectableItem)
        {
            if (_value != null)
            {
                SetOldMaterials();
            }
            _value = selectableItem;

            SetNewMaterials();
        }

        private void SetNewMaterials()
        {
            foreach (var renderer in _value.MeshRenderers)
            {
                _newMaterials = new List<Material>
                {
                    _outLineMaterial
                };
                _newMaterials.AddRange(renderer.materials);

                renderer.materials = _newMaterials.ToArray();
            }
        }

        private void SetOldMaterials()
        {
            foreach (var renderer in _value.MeshRenderers)
            {
                _oldMaterials = renderer.materials
                    .Where(material => material.shader.name != _outLineMaterial.shader.name).ToArray();
                renderer.materials = _oldMaterials;
            }
        }

        #endregion
    }
}