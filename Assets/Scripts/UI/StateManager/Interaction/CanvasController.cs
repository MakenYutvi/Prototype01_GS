using UnityEngine;
using Zenject;

namespace Foundation
{
    public sealed class CanvasController : AbstractBehaviour,
        IOnStateActivate,
        IOnStateDeactivate,
        IOnStateBecomeTopmost,
        IOnStateResignTopmost,
        IOnStateSortingOrderChanged
    {
        public Canvas Canvas;
        public CanvasGroup CanvasGroup;
        public Camera EditorCamera;

        [Inject] ISceneState state = default;

        void Awake()
        {
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.alpha = 0.0f;

            if (EditorCamera != null)
            {
                if (Canvas.renderMode == RenderMode.ScreenSpaceCamera && Canvas.worldCamera == EditorCamera)
                    Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                Destroy(EditorCamera);
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
            CanvasGroup.interactable = true;
        }

        void IOnStateResignTopmost.Do()
        {
            CanvasGroup.interactable = false;
        }

        void IOnStateActivate.Do()
        {
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.alpha = 1.0f;
        }

        void IOnStateDeactivate.Do()
        {
            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.alpha = 0.0f;
        }

        void IOnStateSortingOrderChanged.Do(int order)
        {
            Canvas.sortingOrder = order;
        }
    }
}
