using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public sealed class TopPanelView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Button _menuButton;

        #endregion


        #region Properties

        public IObservable<Unit> MenuButtonClick => _menuButton.OnClickAsObservable();
        public string TimeFormatted
        {
            set => _textMeshPro.text = value;
        }

        #endregion
    }
}