using UnityEngine;

namespace ECS
{
    public sealed class PlayerAttackElement : MonoElement, IAttackElement
    {
        [SerializeField]
        private WeaponService weaponService;

        public bool CanAttack()
        {
            if (!this.weaponService.TryGetCurrentWeapon(out var weapon))
            {
                return false;
            }
            
            if (!weapon.TryGetElement(out IAttackElement component))
            {
                return false;
            }

            return component.CanAttack();
        }

        public void Attack()
        {
            if (!this.weaponService.TryGetCurrentWeapon(out var weapon))
            {
                return;
            }
            
            if (!weapon.TryGetElement(out IAttackElement component))
            {
                return;
            }

            component.Attack();
        }
    }
}