using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IBulletManager
    {
    public delegate void OnCollide(Bullet bullet, Collider target);
    public abstract event OnCollide OnCollideEvent;
    void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction, IBulletListener listener = null);
    }

