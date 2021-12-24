using System;

namespace Igor
{
    public interface IPopupListener
    {
        void OnPopupVisible(Type popupType, bool isVisible);

        void OnPopupActive(Type popupType, bool isActive);
    }
}