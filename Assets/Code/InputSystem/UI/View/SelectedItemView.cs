using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public sealed class SelectedItemView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private Slider _healthBar;

        public Sprite Icon
        {
            set => _icon.sprite = value;
        }

        public string Name
        {
            set => _name.text = value;
        }

        public string Health
        {
            set => _health.text = value;
        }

        public float HealthBar
        {
            set => _healthBar.value = value;
        }
    }
}