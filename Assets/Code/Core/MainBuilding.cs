using UnityEngine;
using Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, ISelectableItem, IUnitProducer
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        private List<MeshRenderer> _meshRenderers;

        public Sprite Icon => _icon;

        public string Name => _name;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public List<MeshRenderer> MeshRenderers => _meshRenderers;

        private void Awake()
        {
            _meshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)), Quaternion.identity, _unitsParent);
        }
    }
}