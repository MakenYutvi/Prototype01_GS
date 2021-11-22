using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    private GameObject _applicationSceneManagerGO;
    private ISceneManager sceneManager;


    private void Awake()
    {
        this.sceneManager = this._applicationSceneManagerGO.GetComponent<ISceneManager>();
    }
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
                    this.sceneManager.LoadSceneAsync("GameMainMenu3");
                }
                else
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }

}


