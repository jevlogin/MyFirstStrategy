using UnityEngine;
using Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectableItem
    {
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        private List<Renderer> _meshRenderers;

        public Sprite Icon => _icon;

        public string Name => _name;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public List<Renderer> Renderers => _meshRenderers;

        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

        private void Awake()
        {
            _meshRenderers = GetComponentsInChildren<Renderer>().ToList();
        }
    }
}