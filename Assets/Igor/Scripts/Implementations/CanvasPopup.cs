using UnityEngine;

namespace Igor
{
    public abstract class CanvasPopup : Popup
    {
        public override bool IsVisible
        {
            get { return this.isVisible; }
        }

        public override bool IsActive
        {
            get { return this.isActive; }
        }

        [SerializeField]
        private CanvasGroup canvasGroup;

        [Space]
        [SerializeField]
        private bool isVisible;

        [SerializeField]
        private bool isActive;

        public override void SetVisible(bool isVisible)
        {
            this.isVisible = isVisible;

            this.canvasGroup.blocksRaycasts = isVisible;
            this.canvasGroup.alpha = isVisible ? 1.0f : 0.0f;
        }

        public override void SetActive(bool isActive)
        {
            this.isActive = isActive;

            this.canvasGroup.interactable = isActive;
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            this.SetVisible(this.isVisible);
            this.SetActive(this.isActive);
        }

        protected void Reset()
        {
            this.canvasGroup = this.GetComponent<CanvasGroup>();
        }
#endif
    }
}