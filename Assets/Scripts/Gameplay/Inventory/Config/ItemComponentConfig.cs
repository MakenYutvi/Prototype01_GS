//using Sirenix.OdinInspector;
using UnityEngine;

namespace Otus.InventoryModule
{
    [CreateAssetMenu(menuName = "Inventory/Item Component")]
    public sealed class ItemComponentConfig : ScriptableObject, IItemComponent//SerializedScriptableObject, IItemComponent
    {
        public ItemType Type
        {
            get { return this.component.Type; }
        }

        [SerializeField]
        private IItemComponent component;
        
        public IItemComponent Clone()
        {
            return this.component.Clone();
        }
    }
}