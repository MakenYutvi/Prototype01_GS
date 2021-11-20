using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    // Start is called before the first frame update
    event Action<Collider> OnCollideEvent;
    private List<WeaponComponent> _weaponComponents;

    public void AddToList(WeaponComponent weaponComponent)
    {
        //Debug.Log("add");
        //Debug.Log(weaponComponent.name);
        //this._weaponComponents.Add(weaponComponent);
        weaponComponent.OnCollideEvent += ProcessDamageEvent;
        
    }
    public void DeleteFromList(WeaponComponent weaponComponent)
    {
        //Debug.Log("delete");
        //this._weaponComponents.Add(weaponComponent);
        weaponComponent.OnCollideEvent -= ProcessDamageEvent;
       
    }
    private void ProcessDamageEvent(Collider collider)
    {
        if(collider.TryGetComponent(out HitPointsComponent component))
        {

        }
    }
}


