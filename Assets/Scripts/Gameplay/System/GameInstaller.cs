using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IBulletManager>()
            .To<BulletManager>()
            .FromComponentInHierarchy()
            .AsCached();


        //Container.Bind<Enemy>().AsSingle().NonLazy();
    }
}