using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletManager : MonoBehaviour, IBulletManager, Bullet.IHandler
{
    [SerializeField]
    private Parameters parameters;

    public void LaunchBullet(
          Vector3 position,
          Quaternion rotation,
          Vector3 direction,
          IBulletListener listener = null
      )
    {
        var prefab = this.parameters.bulletPrefab;
        var bulletRoot = this.parameters.bulletContainer;
        var bullet = Instantiate(prefab, position, rotation, bulletRoot);
        bullet.SetHandler(this);
        bullet.SetDirection(direction);
        bullet.SetLifetime(this.parameters.config.lifetime);
        bullet.SetSpeed(this.parameters.config.speed);
        //this.activeBullets.Add(bullet);

        if (listener != null)
        {
            //this.bulletListenerMap.Add(bullet, listener);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void Bullet.IHandler.OnBulletCollided(Bullet bullet, Collider target)
    {
        //if (this.bulletListenerMap.TryGetValue(bullet, out var listener))
        //{
        //    listener.OnBulletCollided(target);
        //    this.DestroyBullet(bullet);
        //}
    }
    [Serializable]
    public sealed class Parameters
    {
        [SerializeField]
        public Bullet bulletPrefab;

        [SerializeField]
        public Transform bulletContainer;

        [SerializeField]
        public BulletConfig config;
    }

}
