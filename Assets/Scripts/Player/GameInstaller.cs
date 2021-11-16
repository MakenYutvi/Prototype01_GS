using System;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBulletManager>()
             .To<BulletManager>().AsSingle();


       //Container.Bind<Enemy>().AsSingle().NonLazy();
    }
}
