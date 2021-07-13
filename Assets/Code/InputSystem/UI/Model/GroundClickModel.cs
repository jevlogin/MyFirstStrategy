using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;


namespace Model
{
    [CreateAssetMenu(fileName = nameof(GroundClickModel), menuName = "Data/" + nameof(GroundClickModel), order = 51)]
    public class GroundClickModel : ScriptableObjectContainerBase<Vector3>
    {
        
    }
}