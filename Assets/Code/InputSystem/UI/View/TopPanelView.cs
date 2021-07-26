using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public sealed class TopPanelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Button _menuButton;

        public string TimeFormatted
        {
            set => _textMeshPro.text = value;
        }

        public Button Button => _menuButton;
        public IObservable<Unit> MenuButtonClick => _menuButton.OnClickAsObservable();
    }
}