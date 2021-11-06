using UnityEngine;

namespace Igor
{
    public sealed class PopupController1 : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private Camera editorCamera;

        private void Awake()
        {
            this.canvasGroup.interactable = false;
            this.canvasGroup.blocksRaycasts = false;
            this.canvasGroup.alpha = 0.0f;

            if (editorCamera != null)
            {
                if (canvas.renderMode == RenderMode.ScreenSpaceCamera &&
                    canvas.worldCamera == editorCamera)
                    canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                Destroy(editorCamera);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Observe(state.OnBecomeTopmost);
            Observe(state.OnResignTopmost);
            Observe(state.OnActivate);
            Observe(state.OnDeactivate);
            Observe(state.OnSortingOrderChanged);
        }

        void IOnStateBecomeTopmost.Do()
        {
            canvasGroup.interactable = true;
        }

        void IOnStateResignTopmost.Do()
        {
            canvasGroup.interactable = false;
        }

        void IOnStateActivate.Do()
        {
            canvasGroup.blocksRaycasts = true;
            if (animator != null)
                animator.AnimateAppear(canvas, canvasGroup);
            else
                canvasGroup.alpha = 1.0f;
        }

        void IOnStateDeactivate.Do()
        {
            canvasGroup.blocksRaycasts = false;
            if (animator != null)
                animator.AnimateDisappear(canvas, canvasGroup);
            else
                canvasGroup.alpha = 0.0f;
        }

        void IOnStateSortingOrderChanged.Do(int order)
        {
            canvas.sortingOrder = order;
        }
    }
}