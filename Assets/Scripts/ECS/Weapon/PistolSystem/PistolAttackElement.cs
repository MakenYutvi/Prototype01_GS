using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class PistolAttackElement : WeaponAttackElementMono
    {
        public override void Attack()
        {
            Debug.Log("Pistol attack");
        }

        public override bool CanAttack()
        {
            return true;
        }
    }
}