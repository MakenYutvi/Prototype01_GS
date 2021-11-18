using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletListener
{
    void OnBulletCollided(Collider collider);
}