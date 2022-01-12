using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponAttackComponent : MonoElement, IAttackComponent
    {
        [SerializeField]
        private WeaponAttackSystem _weaponAttackSystem;
        public void Attack()
        {
            if(_weaponAttackSystem.CanAttack())
            {
                _weaponAttackSystem.Attack();
            }
        }

        public bool CanAttack()
        {
            return _weaponAttackSystem.CanAttack();
        }
    }
}