using UnityEngine;
using Zenject;

namespace Igor
{
    public sealed class PopupManagerInjector : MonoInstaller
    {
        [SerializeField]
        private PopupManager popupManager;
        
        public override void InstallBindings()
        {
            this.Container.Bind<IPopupManager>().FromInstance(this.popupManager);
        }
    }
}