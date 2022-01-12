using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponAttackSystem : WeaponAttackElementMono
    {
        [SerializeField]
        private List<WeaponAttackElementMono> _weaponComponents;

        public override void Attack()
        {
            if(CanAttack())
            {
                _weaponComponents.ForEach(w => w.Attack());
            }
            
        }

        public override bool CanAttack()
        {
            foreach (var element in _weaponComponents)
            {
                if(!element.CanAttack())
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}