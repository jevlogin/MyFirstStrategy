using Abstractions;
using System;
using UnityEngine;
using Zenject;

namespace Model
{
    public sealed class PatroulUnitCommandCreator : CancelableCommandCreator<IPatroulCommand, Vector3>
    {
        [Inject] private SelectedItemModel _selectedItemModel;
        protected override IPatroulCommand GetCommandT(Vector3 paramResult)
        {
            return new PatroulUnitCommand(_selectedItemModel.Value.CurrentPosition, paramResult);
        }
    }
}