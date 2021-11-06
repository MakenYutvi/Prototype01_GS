using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Igor
{
    public sealed class ButtonNext : MonoBehaviour, IPopupListener
    {
        [Inject]
        private IPopupManager popupManager;

        [Space]
        [SerializeField]
        private Button nextButton;

        private void OnEnable()
        {
            this.nextButton.onClick.AddListener(this.OnNextButtonClicked);
            this.popupManager.AddListener<Popup1>(this);
        }

        private void Start()
        {
            this.nextButton.interactable = !this.popupManager.IsPopupVisible<Popup1>();
        }

        private void OnDisable()
        {
            this.nextButton.onClick.RemoveListener(this.OnNextButtonClicked);
            this.popupManager.RemoveListener<Popup1>(this);
        }

        private void OnNextButtonClicked()
        {
            this.popupManager.ShowPopup<Popup1>();
        }

        void IPopupListener.OnPopupVisible(Type popupType, bool isVisible)
        {
            this.nextButton.interactable = !isVisible;
            Debug.Log($"BUTTON: POPUP VISIBLE {popupType.Name} {isVisible}");
        }

        void IPopupListener.OnPopupActive(Type popupType, bool isActive)
        {
            Debug.Log($"BUTTON: POPUP ACTIVE {popupType.Name} {isActive}");
        }
    }
}