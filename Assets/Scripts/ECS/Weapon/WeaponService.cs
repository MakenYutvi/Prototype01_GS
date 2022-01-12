using UnityEngine;

namespace ECS
{
    public abstract class WeaponService : MonoBehaviour
    {
        public abstract bool TryGetCurrentWeapon(out IEntity weapon);

        public abstract void NextWeapon();

        public abstract void PreviousWeapon();
    }
}