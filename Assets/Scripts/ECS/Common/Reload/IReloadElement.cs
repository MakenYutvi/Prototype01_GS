namespace ECS
{
    public interface IReloadElement
    {
        bool CanReload();

        void Reload();
    }
}