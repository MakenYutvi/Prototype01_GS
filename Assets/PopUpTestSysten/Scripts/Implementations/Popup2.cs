using UnityEngine;
using UnityEngine.UI;

namespace Igor
{
    public sealed class Popup2 : CanvasPopup
    {
        [SerializeField]
        private Button returnButton;

        private void OnEnable()
        {
            this.returnButton.onClick.AddListener(this.OnReturnButtonClicked);
        }

        private void OnDisable()
        {
            this.returnButton.onClick.RemoveListener(this.OnReturnButtonClicked);
        }

        private void OnReturnButtonClicked()
        {
            this.Close();
        }
    }
}