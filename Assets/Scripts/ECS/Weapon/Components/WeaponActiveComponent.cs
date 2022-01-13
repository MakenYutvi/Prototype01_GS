using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ECS
{
    public class WeaponActiveComponent : MonoElement, IWeaponActiveComponent
    {
        [SerializeField]
        private WeaponActivateController _activeController;

        public event Action<bool> OnActive;

        public void SetActiveVisual(bool isActive)
        {
            _activeController.SetActiveVisual(isActive);
            OnActive?.Invoke(isActive);
        }
    }
}