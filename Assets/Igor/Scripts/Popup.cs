using UnityEngine;

namespace Igor
{
    public abstract class Popup : MonoBehaviour, IPopup
    {
        public abstract bool IsVisible { get; }
        
        public abstract bool IsActive { get; }
        
        public abstract void SetVisible(bool isVisible);

        public abstract void SetActive(bool isActive);
    }
}