using System.Collections.Generic;

namespace ECS
{


    public interface IWeaponService
    {

        event Action OnCurrentWeaponChanged;
        bool TryGetCurrentWeapon(out IEntity weapon);
        void SetCurrentWeapon(WeaponStateID weaponID);
        List<MonoEntity> GetAllWeapons();
    }
}