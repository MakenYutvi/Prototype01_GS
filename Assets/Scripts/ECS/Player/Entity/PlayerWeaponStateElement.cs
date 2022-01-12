using UnityEngine;

namespace ECS
{
    public sealed class PlayerWeaponStateElement : MonoElement, IWeaponStateElement
    {
        [SerializeField]
        private WeaponService weaponService;
        
        public void NextWeapon()
        {
            this.weaponService.NextWeapon();
        }

        public void PreviousWeapon()
        {
            this.weaponService.PreviousWeapon();
        }
    }
}