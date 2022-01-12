using UnityEngine;

namespace ECS
{
    public sealed class PlayerReloadElement : MonoElement, IReloadElement
    {
        [SerializeField]
        private WeaponService weaponService;

        public bool CanReload()
        {
            if (!this.weaponService.TryGetCurrentWeapon(out var weapon))
            {
                return false;
            }
            
            if (!weapon.TryGetElement(out IReloadElement component))
            {
                return false;
            }

            return component.CanReload();
        }

        public void Reload()
        {
            if (!this.weaponService.TryGetCurrentWeapon(out var weapon))
            {
                return;
            }
            
            if (!weapon.TryGetElement(out IReloadElement component))
            {
                return;
            }

            component.Reload();
        }
    }
}