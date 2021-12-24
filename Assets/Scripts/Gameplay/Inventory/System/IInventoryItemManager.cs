using System;

namespace Otus.InventoryModule
{
    public interface IInventoryItemManager
    {
        event Action<Item> OnItemAdded;

        event Action<Item> OnItemRemoved;

        Item[] GetItems(ItemType typeMask);

        Item[] GetItems(Type componentType);

        Item[] GetAllItems();
        
        bool ContainsItem(Item item);
        
        void AddItem(Item item);

        void RemoveItem(Item item);

        int GetCountsOfItems(Item item);

        void RemoveNItems(Item item, int counts);
    }
}