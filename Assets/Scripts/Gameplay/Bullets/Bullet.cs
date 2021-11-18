using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float _lifeTime;
    private float _speed;
    private IHandler _handler;
    private Vector3 _direction;
    private float _fixedDeltaTime;


    public void SetLifetime(float lifetime)
    {
        this._lifeTime = lifetime;
    }

    public void SetSpeed(float speed)
    {
        this._speed = speed;
    }

    public void SetDirection(Vector3 direction)
    {
        this._direction = direction;
    }

    private void Awake()
    {
        _fixedDeltaTime = Time.fixedDeltaTime;
    }

    //public bool Move()
    void FixedUpdate()
    {
        if (this._lifeTime > 0)
        {
            this.transform.position += this._speed * _fixedDeltaTime * this._direction;
            this._lifeTime -= _fixedDeltaTime;
            //return true;
        }

        //return false;
    }

    public void SetHandler(IHandler handler)
    {
        this._handler = handler;
    }

    private void OnTriggerEnter(Collider other)
    {
        this._handler.OnBulletCollided(this, other);
    }

    public interface IHandler
    {
        void OnBulletCollided(Bullet bullet, Collider target);
    }
}
