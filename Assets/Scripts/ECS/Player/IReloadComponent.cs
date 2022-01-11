namespace ECS
{
    public interface IReloadComponent
    {
        bool CanReload();
        void Reload();
    }
}
