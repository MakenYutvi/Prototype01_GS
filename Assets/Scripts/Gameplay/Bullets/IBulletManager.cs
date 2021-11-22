using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IBulletManager
    {
    //event Action<Collider> OnCollideEvent;
    void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction, IBulletListener listener = null);
    }

