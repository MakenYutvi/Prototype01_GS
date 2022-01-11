namespace ECS
{


    public interface IWeaponService
    {

        event Action OnCurrentWeaponChanged;
        Entity GetCurrentWeapon();
        void SetCurrentWeapon(Entity weapon);
        Entity[] GetAllWeapons();
    }
}