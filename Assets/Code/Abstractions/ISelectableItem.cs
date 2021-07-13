using System.Collections.Generic;
using UnityEngine;


namespace Abstractions
{
    public interface ISelectableItem : IHealthHolder
    {
        Sprite Icon { get; }
        List<Renderer> Renderers { get; }
        Vector3 CurrentPosition { get; }
        string Name { get; }
    }
}