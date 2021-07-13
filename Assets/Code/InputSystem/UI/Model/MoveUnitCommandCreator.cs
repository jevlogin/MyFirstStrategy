using Abstractions;
using InputSystem;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utils;
using Zenject;


namespace Model
{
    public sealed class MoveUnitCommandCreator : CancelableCommandCreator<IMoveCommand, Vector3>
    {
        protected override IMoveCommand GetCommandT(Vector3 paramResult) => new MoveUnitCommand(paramResult);
    }
}