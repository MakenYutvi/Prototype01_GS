using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour, IDamageController
{


    public event Action<bool> IsPlayerDied;

    public void Subscribe(WeaponComponent weaponComponent)
    {     
        weaponComponent.OnCollideEvent += ProcessDamageEvent;
        
    }
    public void UnSubscribe(WeaponComponent weaponComponent)
    {    
        weaponComponent.OnCollideEvent -= ProcessDamageEvent;      
    }
    private void ProcessDamageEvent(Collider collider, int damage)
    {
        //Debug.Log("debug throw DamageController");
        if (collider.TryGetComponent(out HitPointsComponent component))
        {
            float target_HP = collider.GetComponent<HitPointsComponent>().GetDamage(damage);
            if (target_HP <= 0)
            {
                if (collider.CompareTag("Player"))
                {
                    IsPlayerDied?.Invoke(true);
                }
                else
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }

}


