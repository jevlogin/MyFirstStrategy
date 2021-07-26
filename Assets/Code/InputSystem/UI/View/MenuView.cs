using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public sealed class MenuView : MonoBehaviour
    {
        [SerializeField] private Button _continue;

        public IObservable<Unit> ContinueButtonClick => _continue.OnClickAsObservable();

    }
}