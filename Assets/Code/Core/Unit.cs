using Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Core
{
    internal sealed class Unit : MonoBehaviour, ISelectableItem
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        [SerializeField] private List<Renderer> _meshRenderers;

        public Sprite Icon => _icon;

        public string Name => _name;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public List<Renderer> Renderers => _meshRenderers;
    }
}