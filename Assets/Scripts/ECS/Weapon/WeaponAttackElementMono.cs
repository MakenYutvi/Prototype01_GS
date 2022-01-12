using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public abstract class WeaponAttackElementMono : MonoBehaviour, IAttackComponent
    {
        public abstract void Attack();


        public abstract bool CanAttack();


      
    }
}