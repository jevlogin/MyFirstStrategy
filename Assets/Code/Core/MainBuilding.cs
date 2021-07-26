using UnityEngine;
using Abstractions;
using System.Collections.Generic;
using System.Linq;
using System;
using UniRx;
using Random = UnityEngine.Random;


namespace Core
{
    public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectableItem, IAttackable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        private List<Renderer> _meshRenderers;
        private ReactiveProperty<float> _reactiveHealth;

        public Sprite Icon => _icon;
        public string Name => _name;
        public IObservable<float> Health => _reactiveHealth;
        public float MaxHealth => _maxHealth;
        public List<Renderer> Renderers => _meshRenderers;
        public Vector3 CurrentPosition => transform.position;


        private void Awake()
        {
            _reactiveHealth = new ReactiveProperty<float>(_health);
            _meshRenderers = GetComponentsInChildren<Renderer>().ToList();
        }

        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
}
