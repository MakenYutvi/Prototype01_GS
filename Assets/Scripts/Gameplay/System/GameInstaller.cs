using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    //[SerializeField]
    //private BulletManager bulletManager;

    public override void InstallBindings()
    {
        
        //Container
        //    .Bind<IBulletManager>()
        //    .To<BulletManager>()
        //    .FromInstance(this.bulletManager);

        Container.Bind<IBulletManager>()
            .To<BulletManager>().FromComponentInHierarchy().AsCached();

        Container.Bind<IWeaponManager>()
            .To<WeaponManager>().FromComponentInHierarchy().AsCached();
        
        Container.Bind<IDamageController>()
            .To<DamageController>().FromComponentInHierarchy().AsCached();

        //Container.Bind<Enemy>().AsSingle().NonLazy();
    }
}
