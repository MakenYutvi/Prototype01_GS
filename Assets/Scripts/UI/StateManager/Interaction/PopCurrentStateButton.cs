using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Foundation
{
    public sealed class PopCurrentStateButton : MonoBehaviour
    {
        [Inject] ISceneStateManager manager = default;
        [Inject] ISceneState state = default;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => manager.Pop(state));
        }
    }
}
