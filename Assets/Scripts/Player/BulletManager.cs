using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;



public class BulletManager : MonoBehaviour, IBulletManager, Bullet.IHandler
{
    [SerializeField]
    private Parameters parameters;
    [SerializeField]
    private GameObject sceneManagerGO;

    private Dictionary<Bullet, IBulletListener> bulletListenerMap;

    private List<Bullet> activeBullets;

    private List<Bullet> processingBullets;

    private ISceneManager sceneManager;

    [Inject]
    private DiContainer container;

    private void Awake()
    {
        this.activeBullets = new List<Bullet>();
        this.processingBullets = new List<Bullet>();
        this.bulletListenerMap = new Dictionary<Bullet, IBulletListener>();
        this.sceneManager = this.sceneManagerGO.GetComponent<ISceneManager>();
    }

    public void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction, IBulletListener listener = null)
    {
        var prefab = this.parameters.bulletPrefab;
        var bulletRoot = this.parameters.bulletContainer;
       
       //Debug.Log($"CONTAINER IS NULL {container == null}");
                if (container == null)
                    {
                        return;
                    }
        
        var bullet1 = container.InstantiatePrefab(prefab, position, rotation, bulletRoot);
        Bullet bullet = bullet1.GetComponent<Bullet>();
        bullet.SetHandler(this);
        bullet.SetDirection(direction);
        bullet.SetLifetime(this.parameters.config.lifetime);
        bullet.SetSpeed(this.parameters.config.speed);
        this.activeBullets.Add(bullet);

        if (listener != null)
        {
            this.bulletListenerMap.Add(bullet, listener);
        }
    }
    private void FixedUpdate()
    {
        this.ProcessBullets();
    }
    void Bullet.IHandler.OnBulletCollided(Bullet bullet, Collider target)
    {
        //ну, это надо переписать
        if(target.GetComponent<HP_component>())
        {
            float target_HP = target.GetComponent<HP_component>().GetDamage(parameters.config.damage);
            if (target_HP <= 0)
            {
                if(target.CompareTag("Player"))
                {
                    this.sceneManager.LoadSceneAsync("GameMainMenu3");
                }
                else
                {
                    Destroy(target.gameObject);
                }
            }
            this.DestroyBullet(bullet);
        }
        //if (this.bulletListenerMap.TryGetValue(bullet, out var listener))
        //{
        //    listener.OnBulletCollided(target);
        //    this.DestroyBullet(bullet);
        //    Debug.Log("debug bullet manager");
        //}
    }
    // Update is called once per frame
    private void ProcessBullets()
    {
        this.processingBullets.Clear();
        this.processingBullets.AddRange(this.activeBullets);
        for (int i = 0, count = this.processingBullets.Count; i < count; i++)
        {
            var bullet = this.processingBullets[i];
            if (!bullet.Move())
            {
                this.DestroyBullet(bullet);
            }
        }
    }

    private void DestroyBullet(Bullet bullet)
    {
        this.bulletListenerMap.Remove(bullet);
        this.activeBullets.Remove(bullet);
        bullet.gameObject.SetActive(false);
        Destroy(bullet.gameObject, 0.1f);
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
