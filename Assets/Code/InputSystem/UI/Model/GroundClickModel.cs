using System;
using UnityEngine;
using Zenject;


namespace Model
{
    [CreateAssetMenu(fileName = nameof(GroundClickModel), menuName = "Data/" + nameof(GroundClickModel), order = 51)]
    public class GroundClickModel : ScriptableObject
    {
        private Vector3 _value;

        public Vector3 Value => _value;

        public void SetValue(Vector3 item)
        {
            _value = item;
            OnUpdated?.Invoke();
        }

        public event Action OnUpdated;
    }
}