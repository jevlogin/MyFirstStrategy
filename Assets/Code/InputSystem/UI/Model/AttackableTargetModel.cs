using Abstractions;
using UnityEngine;


namespace Model
{
    [CreateAssetMenu(fileName = nameof(AttackableTargetModel), menuName = "Data/" + nameof(AttackableTargetModel), order = 51)]
    public sealed class AttackableTargetModel : ScriptableObjectContainerBase<IAttackable>
    {

    }
}