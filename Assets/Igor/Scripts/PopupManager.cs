using System;
using System.Collections.Generic;
using UnityEngine;

namespace Igor
{
    public sealed class PopupManager : MonoBehaviour, IPopupManager
    {
        public IPopup CurrentPopup
        {
            get { return this.currentPopup; }
        }

        [SerializeField]
        private Popup[] popups;

        private Popup currentPopup;

        private Dictionary<Type, Popup> popupDictionary;

        private List<Popup> visiblePopupList;

        private void Awake()
        {
            this.InitializePopups();
        }

        public void ShowPopup<T>() where T : IPopup
        {
            if (this.FindVisiblePopup<T>(out var targetPopup))
            {
                var popup = targetPopup as Popup;
                this.MovePopupFirst(popup);
            }
            else
            {
                var popup = this.popupDictionary[typeof(T)];
                this.ShowPopup(popup);
            }
        }

        public void HidePopup<T>() where T : IPopup
        {
            if (!this.FindVisiblePopup<T>(out var targetPopup))
            {
                return;
            }

            var popup = targetPopup as Popup;
            this.HidePopup(popup);
        }

        public void AddListener<T>(IPopupListener<T> listener) where T : IPopup
        {
        }

        public void RemoveListener<T>(IPopupListener<T> listener) where T : IPopup
        {
        }

        private void InitializePopups()
        {
            var count = this.popups.Length;
            this.popupDictionary = new Dictionary<Type, Popup>(count);
            this.visiblePopupList = new List<Popup>(count);
            for (var i = 0; i < count; i++)
            {
                var popup = this.popups[i];
                popup.SetActive(false);

                var type = popup.GetType();
                this.popupDictionary.Add(type, popup);
            }
        }

        private bool FindVisiblePopup<T>(out T popup)
        {
            for (int i = 0, count = this.visiblePopupList.Count; i < count; i++)
            {
                var visiblePopup = this.visiblePopupList[i];
                if (visiblePopup is T result)
                {
                    popup = result;
                    return true;
                }
            }

            popup = default;
            return false;
        }

        private void MovePopupFirst(Popup popup)
        {
            this.visiblePopupList.Remove(popup);
            this.visiblePopupList.Add(popup);
            this.UpdateCurrentPopup(popup);
        }

        private void ShowPopup(Popup popup)
        {
            popup.SetVisible(true);
            this.visiblePopupList.Add(popup);
            this.UpdateCurrentPopup(popup);
        }

        private void UpdateCurrentPopup(Popup newPopup)
        {
            var previousPopup = this.currentPopup;
            if (previousPopup == newPopup)
            {
                return;
            }
            
            if (previousPopup != null)
            {
                previousPopup.SetActive(false);
            }

            this.currentPopup = newPopup;
            newPopup.SetActive(true);
        }

        private void HidePopup(Popup popup)
        {
            this.visiblePopupList.Remove(popup);
         
            if (popup == this.currentPopup)
            {
                popup.SetActive(false);
                
                var visibleCount = this.visiblePopupList.Count;
                if (visibleCount > 0)
                {
                    var topIndex = visibleCount - 1;
                    var nextPopup = this.visiblePopupList[topIndex];
                    nextPopup.SetActive(true);
                    this.currentPopup = nextPopup;
                }
                else
                {
                    this.currentPopup = null;
                }
            }
            
            popup.SetVisible(false);
        }
    }
}