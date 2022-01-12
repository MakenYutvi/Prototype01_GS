namespace ECS
{


    public interface IWeaponService
    {

        event Action OnCurrentWeaponChanged;
        bool TryGetCurrentWeapon(out IEntity weapon);
        void SetCurrentWeapon(MonoEntity weapon);
        MonoEntity[] GetAllWeapons();
    }
}