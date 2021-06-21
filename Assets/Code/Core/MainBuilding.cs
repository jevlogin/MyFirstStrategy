using UnityEngine;
using Abstractions;


namespace Core
{
    public sealed class MainBuilding : MonoBehaviour, ISelectableItem
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public Sprite Icon => _icon;

        public string Name => _name;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)), Quaternion.identity, _unitsParent);
        }
    }
}