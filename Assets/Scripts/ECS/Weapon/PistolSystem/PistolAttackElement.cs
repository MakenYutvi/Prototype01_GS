using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace ECS
{
    public class PistolAttackElement : WeaponAttackElementMono
    {
        [SerializeField]
        private int _damage = 5;//задел на будущее
        [SerializeField]
        private GameObject _firePoint;


        private IBulletManager _BulletManager;
        public event ActionWeapon<Collider> OnCollideEvent;

        [Inject]
        public void Construct(IBulletManager bulletManager)
        {
            _BulletManager = bulletManager;
        }
        public override void Attack()
        {
            Debug.Log("Pistol attack");
            _BulletManager.LaunchBullet(this.transform.position + _firePoint.transform.forward, this.transform.rotation, _firePoint.transform.forward, null);
        }

        public override bool CanAttack()
        {
            return true;
        }
    }
}