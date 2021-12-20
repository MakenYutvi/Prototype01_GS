using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponState : MonoBehaviour,  IWeaponState
{
    public virtual void Attack()
    {
       
    }

    public virtual void OnActivate()
    {
        
    }

    public virtual void OnDeactivate()
    {
        
    }
}
