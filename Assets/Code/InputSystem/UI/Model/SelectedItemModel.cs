using Abstractions;
using System;
using UnityEngine;


namespace Model
{
    [CreateAssetMenu(fileName = "SelectedItemModel", menuName = "Data/SelectedItemModel", order = 51)]
    public sealed class SelectedItemModel : ScriptableObjectContainerBase<ISelectableItem>
    {
       
    }
}