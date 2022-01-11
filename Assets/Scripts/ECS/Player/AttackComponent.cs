using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{


    public class AttackComponent : ComponentEntity, IAttackComponent
    {
       
        public virtual void Attack()
        {
            Debug.Log("debug: AttackComponent");
        }

        public virtual bool CanAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}