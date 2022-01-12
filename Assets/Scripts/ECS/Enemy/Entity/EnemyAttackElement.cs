using UnityEngine;

namespace ECS
{
    public sealed class EnemyAttackElement : MonoElement, IAttackElement
    {
        [SerializeField]
        private MonoEntity weapon;
        
        public bool CanAttack()
        {
            if (!this.weapon.TryGetElement(out IAttackElement element))
            {
                return false;
            }

            return element.CanAttack();
        }

        public void Attack()
        {
            if (!this.weapon.TryGetElement(out IAttackElement component))
            {
                return;
            }

            component.Attack();
        }
    }
}