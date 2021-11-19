using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponComponent : MonoBehaviour
{
    // Start is called before the first frame update

    private IBulletManager _BulletManager;

    public delegate void OnCollide(Bullet bullet, Collider target);
    public event OnCollide OnCollideEvent;

    [Inject]
    public void Construct(IBulletManager bulletManager)
    {
        _BulletManager = bulletManager;
    }

    private void Awake()
    {
       _BulletManager.OnCollideEvent += OnCollidef;
    }
    public void Attack(Vector3 direction)
    {  
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1000);
        
        _BulletManager.LaunchBullet(this.transform.position + direction, this.transform.rotation, direction, null);


    }

    private void OnCollidef(Bullet bullet, Collider target)
    {
        Debug.Log(bullet.name + target.name);
    }

}
