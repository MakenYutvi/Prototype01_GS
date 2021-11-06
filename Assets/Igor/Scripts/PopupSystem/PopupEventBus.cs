using System;
using System.Collections.Generic;

namespace Igor
{
    public sealed class PopupEventBus
    {
        private readonly Dictionary<Type, List<IPopupListener>> listenerTable;

        public PopupEventBus()
        {
            this.listenerTable = new Dictionary<Type, List<IPopupListener>>();
        }

        public void AddListener(Type popupType, IPopupListener listener)
        {
            if (!this.listenerTable.TryGetValue(popupType, out var listeners))
            {
                listeners = new List<IPopupListener>();
                this.listenerTable[popupType] = listeners;
            }
            
            listeners.Add(listener);
        }

        public void RemoveListener(Type popupType, IPopupListener listener)
        {
            if (this.listenerTable.TryGetValue(popupType, out var listeners))
            {
                listeners.Remove(listener);
            }
        }
        
        public void NotifyPopupVisible(Type popupType, bool isVisible)
        {
            if (!this.listenerTable.TryGetValue(popupType, out var listeners))
            {
                return;
            }
            
            for (int i = 0, count = listeners.Count; i < count; i++)
            {
                var listener = listeners[i];
                listener.OnPopupVisible(popupType, isVisible);
            }
        }

        public void NotifyPopupActive(Type popupType, bool isActive)
        {
            if (!this.listenerTable.TryGetValue(popupType, out var listeners))
            {
                return;
            }
            
            for (int i = 0, count = listeners.Count; i < count; i++)
            {
                var listener = listeners[i];
                listener.OnPopupActive(popupType, isActive);
            }
        }
    }
}