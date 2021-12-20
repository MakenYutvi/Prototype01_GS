using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponComponent : WeaponComponentBase, IBulletListener
{
    [SerializeField]
    private int _damage = 5;//задел на будущее
    [SerializeField]
    private GameObject _firePoint;
    private IDamageController _damageController;

    private IBulletManager _BulletManager;
    public event ActionWeapon<Collider> OnCollideEvent;

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
    }
    [Inject]
    public void Construct(IDamageController damageController)
    {
        _damageController = damageController;
    }
    private void OnEnable()
    {
        _damageController.Subscribe(this);
    }

    private void OnDisable()
    {
        _damageController.UnSubscribe(this);
    }
    public void Attack(Vector3 direction)//rudement
    {  
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);       
        _BulletManager.LaunchBullet(this.transform.position + direction, this.transform.rotation, direction, this);
    }
    public override void Attack()
    {  
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);       
        _BulletManager.LaunchBullet(this.transform.position + _firePoint.transform.forward, this.transform.rotation, _firePoint.transform.forward, this);
    }

    public void OnBulletCollided(Collider collider)
    {
        //Debug.Log("debug throw listener");
        OnCollideEvent?.Invoke(collider, _damage);
    }

    public void OnActivate()
    {
        this.gameObject.SetActive(true);
    }

    public void OnDeactivate()
    {
        this.gameObject.SetActive(false);
    }
}
