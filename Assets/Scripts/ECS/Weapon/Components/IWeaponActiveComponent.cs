namespace ECS
{
    public interface IWeaponActiveComponent
    {
        event Action<bool> OnActive;

        void SetActiveVisual(bool isActive);
    }
}