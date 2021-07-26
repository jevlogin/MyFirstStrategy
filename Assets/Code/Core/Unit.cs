using Abstractions;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace Core
{
    internal sealed class Unit : MonoBehaviour, ISelectableItem, IAttackable
    {
        #region Fields

        [SerializeField] private List<Renderer> _meshRenderers;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        private ReactiveProperty<float> _reactiveHealth;

        #endregion


        #region Properties

        public List<Renderer> Renderers => _meshRenderers;
        public Sprite Icon => _icon;
        public Vector3 CurrentPosition => transform.position;
        public string Name => _name;
        public IObservable<float> Health => _reactiveHealth;
        public float MaxHealth => _maxHealth;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _reactiveHealth = new ReactiveProperty<float>(_health);
        }


        private void Update()
        {
            _reactiveHealth.Value -= Time.deltaTime;
        }

        #endregion
    }
}