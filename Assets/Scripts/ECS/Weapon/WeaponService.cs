using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponService : MonoBehaviour, IWeaponService
    {
        [SerializeField]
        private MonoEntity[] _weapons;
        [SerializeField]//test
        private MonoEntity _currentWeapon;

        public event Action OnCurrentWeaponChanged;

        public MonoEntity[] GetAllWeapons()
        {
            return _weapons;
        }

        public void SetCurrentWeapon(MonoEntity weapon)
        {
            OnCurrentWeaponChanged?.Invoke();
           //to do
            
        }

        public bool TryGetCurrentWeapon(out IEntity weapon)
        {
            if (_currentWeapon != null)
            {
                weapon =  _currentWeapon;
                return true;
            }

            weapon = null;
            return false;
        }
    }

}
