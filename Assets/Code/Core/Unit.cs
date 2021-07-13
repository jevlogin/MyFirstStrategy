using Abstractions;
using System.Collections.Generic;
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

        #endregion


        #region Properties

        public List<Renderer> Renderers => _meshRenderers;
        public Sprite Icon => _icon;
        public Vector3 CurrentPosition => transform.position; 
        public string Name => _name;
        public float Health => _health;
        public float MaxHealth => _maxHealth;

        #endregion
    }
}