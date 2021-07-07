using Abstractions;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandExecutors
{
    public sealed class PatroulCommandExecutor : CommandExecutorBase<IPatroulCommand>
    {
        protected override void ExecuteSpecificCommand(IPatroulCommand command)
        {
            Debug.Log($"{name} is Patroul!");
        }
    }
}