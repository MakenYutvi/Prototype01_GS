using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponActivateController : MonoBehaviour, IWeaponActiveComponent
    {
        [SerializeField]
        private GameObject _weaponGO;
        public event Action<bool> OnActive;

        public void SetActiveVisual(bool isActive)
        {
            _weaponGO.SetActive(isActive);
            OnActive?.Invoke(isActive);
        }
    }
}