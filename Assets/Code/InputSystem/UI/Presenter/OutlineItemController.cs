using Abstractions;
using Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Presenter
{
    public sealed class OutlineItemController : MonoBehaviour
    {
        [SerializeField] private SelectedItemModel _model;

        [SerializeField] private Material _outlineMaterial;
        [SerializeField] private List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();
        [SerializeField] private Material[] _oldMaterials;
        [SerializeField] private Material[] _newMaterials;
        [SerializeField] private bool _isSelected = false;

        private void Awake()
        {
            _meshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();
            SetNewMaterialsOutline();
            _oldMaterials = _meshRenderers.FirstOrDefault().materials;
            _model.OnUpdated += UpdateOutline;
        }

       

        private void OnDestroy()
        {
            _model.OnUpdated -= UpdateOutline;
        }

        private void UpdateOutline(ISelectableItem selectableItem)
        {
            foreach (var renderer in _meshRenderers)
            {
                if (_isSelected)
                {
                    renderer.materials = _oldMaterials;
                    _isSelected = !_isSelected;
                }
                else
                {
                    renderer.materials = _newMaterials;
                    _isSelected = !_isSelected;
                }

            }
        }

        private void SetNewMaterialsOutline()
        {
            foreach (var renderer in _meshRenderers)
            {
                _newMaterials = new Material[renderer.materials.Length + 1];

                for (int i = 0; i < _newMaterials.Length; i++)
                {
                    if (i == 0)
                    {
                        _newMaterials[i] = _outlineMaterial;
                        continue;
                    }
                    _newMaterials[i] = renderer.materials[i - 1];
                }
            }
        }
    }
}