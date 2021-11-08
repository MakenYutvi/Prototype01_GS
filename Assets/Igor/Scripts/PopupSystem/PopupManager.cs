using System;
using System.Collections.Generic;
using UnityEngine;

namespace Igor
{
    public sealed class PopupManager : MonoBehaviour, IPopupManager, Popup.IHandler
    {
        [SerializeField]
        private Popup[] popups;

        private Popup currentPopup;

        private Dictionary<Type, Popup> popupDictionary;

        private List<Popup> visiblePopupList;

        private readonly PopupEventBus eventBus;

        public PopupManager()
        {
            this.eventBus = new PopupEventBus();
        }

        private void Awake()
        {
            this.InitializePopups();
        }

        public void ShowPopup<T>()
        {
            var popup = this.popupDictionary[typeof(T)];
            if (this.visiblePopupList.Contains(popup))
            {
                this.MovePopupFirst(popup);
            }
            else
            {
                this.ShowPopup(popup);
            }
        }

        public void HidePopup<T>()
        {
            var popup = this.popupDictionary[typeof(T)];
            this.HidePopup(popup);
        }

        public bool IsPopupVisible<T>()
        {
            var popup = this.popupDictionary[typeof(T)];
            return popup.IsVisible;
        }

        public bool IsPopupActive<T>()
        {
            var popup = this.popupDictionary[typeof(T)];
            return popup.IsActive;
        }

        public void AddListener<T>(IPopupListener listener)
        {
            var popupType = typeof(T);
            this.eventBus.AddListener(popupType, listener);
        }

        public void RemoveListener<T>(IPopupListener listener)
        {
            var popupType = typeof(T);
            this.eventBus.RemoveListener(popupType, listener);
        }

        void Popup.IHandler.Close(Popup popup)
        {
            this.HidePopup(popup);
        }

        private void InitializePopups()
        {
            var count = this.popups.Length;
            this.popupDictionary = new Dictionary<Type, Popup>(count);
            this.visiblePopupList = new List<Popup>(count);
            for (var i = 0; i < count; i++)
            {
                var popup = this.popups[i];
                popup.SetupHandler(this);
                popup.SetVisible(false);
                popup.SetActive(false);

                var type = popup.GetType();
                this.popupDictionary.Add(type, popup);
            }
        }

        private void MovePopupFirst(Popup popup)
        {
            this.visiblePopupList.Remove(popup);
            this.visiblePopupList.Add(popup);
            this.SetCurrentPopup(popup);
        }

        private void ShowPopup(Popup popup)
        {
            popup.SetVisible(true);
            this.visiblePopupList.Add(popup);
            this.eventBus.NotifyPopupVisible(popup.GetType(), true);

            this.SetCurrentPopup(popup);
        }

        private void HidePopup(Popup popup)
        {
            if (!this.visiblePopupList.Contains(popup))
            {
                return;
            }

            this.visiblePopupList.Remove(popup);
            this.ResetCurrentPopup(popup);
            popup.SetVisible(false);
            this.eventBus.NotifyPopupVisible(popup.GetType(), false);
        }

        private void SetCurrentPopup(Popup newPopup)
        {
            var previousPopup = this.currentPopup;
            if (previousPopup == newPopup)
            {
                return;
            }

            if (previousPopup != null)
            {
                previousPopup.SetActive(false);
                this.eventBus.NotifyPopupActive(previousPopup.GetType(), false);
            }

            newPopup.SetActive(true);
            newPopup.transform.SetAsLastSibling();
            this.eventBus.NotifyPopupActive(newPopup.GetType(), true);

            this.currentPopup = newPopup;
        }

        private void ResetCurrentPopup(Popup popup)
        {
            if (popup != this.currentPopup)
            {
                return;
            }

            popup.SetActive(false);
            this.eventBus.NotifyPopupActive(popup.GetType(), false);

            var visibleCount = this.visiblePopupList.Count;
            if (visibleCount <= 0)
            {
                this.currentPopup = null;
                return;
            }

            var topIndex = visibleCount - 1;
            var nextPopup = this.visiblePopupList[topIndex];
            nextPopup.SetActive(true);
            this.eventBus.NotifyPopupActive(nextPopup.GetType(), true);

            this.currentPopup = nextPopup;
        }
    }
}