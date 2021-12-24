using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Igor
{
    public sealed class Popup1 : CanvasPopup
    {
        [Inject]
        private IPopupManager popupManager;

        [Space]
        [SerializeField]
        private Button nextButton;

        [SerializeField]
        private Button returnButton;
        
        private void OnEnable()
        {
            this.nextButton.onClick.AddListener(this.OnNextButtonClicked);
            this.returnButton.onClick.AddListener(this.OnReturnClicked);
        }

        private void OnDisable()
        {
            this.nextButton.onClick.RemoveListener(this.OnNextButtonClicked);
            this.returnButton.onClick.RemoveListener(this.OnReturnClicked);
        }

        private void OnNextButtonClicked()
        {
            this.popupManager.ShowPopup<Popup2>();
        }

        private void OnReturnClicked()
        {
            this.Close();
        }
    }
}