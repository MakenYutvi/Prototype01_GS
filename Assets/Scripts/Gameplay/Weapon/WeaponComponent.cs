using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponComponent : MonoBehaviour
{
    [SerializeField]
    private DamageController _damageController;

    private IBulletManager _BulletManager;
    public event Action<Collider> OnCollideEvent;

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
    }

    private void Awake()
    {
       _BulletManager.OnCollideEvent += OnCollideWeaponEvent;
       
    }

    private void Start()
    {
        _damageController.AddToList(this);
        Debug.Log("debug awake");
    }
    public void Attack(Vector3 direction)
    {  
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);
        
        _BulletManager.LaunchBullet(this.transform.position + direction, this.transform.rotation, direction, null);


    }

    private void OnCollideWeaponEvent(Collider target)
    {
        OnCollideEvent?.Invoke(target);
    }

}
