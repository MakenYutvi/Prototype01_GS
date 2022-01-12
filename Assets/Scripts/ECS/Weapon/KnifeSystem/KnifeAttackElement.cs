using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class KnifeAttackElement : WeaponAttackElementMono
    {
        public override void Attack()
        {
            Debug.Log("knife attack");
        }

        public override bool CanAttack()
        {
            return true;
        }

    
    }
}