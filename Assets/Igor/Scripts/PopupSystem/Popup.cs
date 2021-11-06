using UnityEngine;

namespace Igor
{
    public abstract class Popup : MonoBehaviour
    {
        public abstract bool IsVisible { get; }

        public abstract bool IsActive { get; }

        private IHandler handler;

        public void SetupHandler(IHandler handler)
        {
            this.handler = handler;
        }
        
        public abstract void SetVisible(bool isVisible);

        public abstract void SetActive(bool isActive);

        protected void Close()
        {
            this.handler.Close(this);
        }
        
        public interface IHandler
        {
            void Close(Popup popup);
        }
    }
}