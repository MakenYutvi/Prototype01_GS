using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponComponentBase : MonoBehaviour, IWeaponComponent
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
