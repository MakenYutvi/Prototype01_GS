using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class PlayerAttackComponent : AttackComponent
    {
        public override void Attack()
        {
            Debug.Log("debug: PlayerAttackComponent");
        }

        public override bool CanAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}