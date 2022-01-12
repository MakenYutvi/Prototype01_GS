using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class PlayerAttackComponent : MonoElement, IAttackComponent
    {
        [SerializeField]
        private WeaponService _weaponService;
        public  void Attack()
        {
            if (!_weaponService.TryGetCurrentWeapon(out var weapon))
            {
                return;
            }

            if (!weapon.TryGetElement(out IAttackComponent component))
            {
                return;
            }

            component.Attack();

        }

        public bool CanAttack()
        {
            Debug.Log("debug: PlayerAttackComponent CanAttack");
            if (!_weaponService.TryGetCurrentWeapon(out var weapon))
            {
                return false;
            }

            if (!weapon.TryGetElement(out IAttackComponent component))
            {
                return false;
            }

            return component.CanAttack();
            
        }
    }
}