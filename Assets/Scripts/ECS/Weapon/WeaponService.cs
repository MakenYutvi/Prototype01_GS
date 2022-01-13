using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponService : MonoBehaviour, IWeaponService
    {
        [SerializeField]
        private List<WeaponInfo> _weapons;
        [SerializeField]//test
        private WeaponInfo _currentWeapon;


        private Dictionary<WeaponStateID, MonoEntity> weaponStateMap;

        public event Action OnCurrentWeaponChanged;

        private void Awake()
        {
            this.weaponStateMap = new Dictionary<WeaponStateID, MonoEntity>();
            foreach (var info in _weapons)
            {
                this.weaponStateMap[info.id] = info.weaponSystem;
            }
        }

        public List<MonoEntity> GetAllWeapons()
        {
            List<MonoEntity> allWeapons = new List<MonoEntity>();
            foreach(var weapon in _weapons)
            {
                allWeapons.Add(weapon.weaponSystem);
            }

            return allWeapons;
        }

        public void SetCurrentWeapon(WeaponStateID weaponID)
        {
            if (weaponID == _currentWeapon.id)
            {
                return;
            }
            
            if (_currentWeapon.weaponSystem.TryGetElement<IWeaponActiveComponent>(out IWeaponActiveComponent element))
            {
                element.SetActiveVisual(false);
            }

            var nextState = weaponStateMap[weaponID];
            if (nextState.TryGetElement<IWeaponActiveComponent>(out IWeaponActiveComponent nextElement))
            {
                nextElement.SetActiveVisual(true);
                _currentWeapon.id = weaponID;
                _currentWeapon.weaponSystem = weaponStateMap[weaponID];
                OnCurrentWeaponChanged?.Invoke();
            }

            

        }

        public bool TryGetCurrentWeapon(out IEntity weapon)
        {
            if (_currentWeapon.weaponSystem != null)
            {
                weapon =  _currentWeapon.weaponSystem;
                return true;
            }

            weapon = null;
            return false;
        }

        [Serializable]
        private struct WeaponInfo
        {
            [SerializeField]
            public WeaponStateID id;

            [SerializeField]
            public MonoEntity weaponSystem;
        }
    }

}
