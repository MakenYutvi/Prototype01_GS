using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Igor
{
    public sealed class CounterWidget : MonoBehaviour, IPopupListener
    {
        [Inject]
        private IPopupManager popupManager;

        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private float counter;

        private void OnEnable()
        {
            this.popupManager.AddListener<Popup2>(this);
        }

        private void Start()
        {
            this.text.enabled = this.popupManager.IsPopupVisible<Popup2>();
        }

        private void Update()
        {
            this.counter += Time.deltaTime;
            this.text.text = $"{this.counter}";
        }

        private void OnDisable()
        {
            this.popupManager.RemoveListener<Popup2>(this);
        }

        void IPopupListener.OnPopupActive(Type popupType, bool isActive)
        {
        }

        void IPopupListener.OnPopupVisible(Type popupType, bool isVisible)
        {
            this.text.enabled = isVisible;
        }
    }
}