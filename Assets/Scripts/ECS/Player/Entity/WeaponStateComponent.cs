using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponStateComponent : MonoElement, IWeaponStateComponent
    {
        [SerializeField]
        private WeaponService _weaponService;
        public void SetState(WeaponStateID weaponID)
        {
            _weaponService.SetCurrentWeapon(weaponID);
        }

   
    }
}