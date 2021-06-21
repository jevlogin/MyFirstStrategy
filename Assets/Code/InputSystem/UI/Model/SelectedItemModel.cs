using Abstractions;
using System;
using UnityEngine;


namespace Model
{
    [CreateAssetMenu(fileName = "SelectedItemModel", menuName = "Data/SelectedItemModel", order = 51)]
    public sealed class SelectedItemModel : ScriptableObject
    {
        private ISelectableItem _value;

        public ISelectableItem Value => _value;

        public void SetValue(ISelectableItem item)
        {
            _value = item;
            OnUpdated?.Invoke();
        }

        public event Action OnUpdated;
    }
}