using System;
using System.Collections.Generic;
using System.Linq;
//using Sirenix.OdinInspector;
using UnityEngine;

namespace Otus.InventoryModule
{
    public sealed class InventoryItemManager : MonoBehaviour, IInventoryItemManager//SerializedMonoBehaviour, IInventoryItemManager
    {
        public event Action<Item> OnItemAdded;
        
        public event Action<Item> OnItemRemoved;
        
        //[ReadOnly]
        //[ShowInInspector]
        [SerializeField]
        private readonly HashSet<Item> items;

        public InventoryItemManager()
        {
            this.items = new HashSet<Item>();
        }

        public void AddItem(Item item)
        {
            if (this.items.Add(item))
            {
                this.OnItemAdded?.Invoke(item);
            }
        }

        public void RemoveItem(Item item)
        {
            if (this.items.Remove(item))
            {
                this.items.Remove(item);
                this.OnItemRemoved?.Invoke(item);
            }
        }

        public Item[] GetAllItems()
        {
            return this.items.ToArray();
        }

        public bool ContainsItem(Item item)
        {
            return true;///////debug
            return this.items.Contains(item);
        }

        public Item[] GetItems(Type componentType)
        {
            var result = new List<Item>();
            foreach (var item in this.items)
            {
                if (item.ContainsComponent(componentType))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        public Item[] GetItems(ItemType typeMask)
        {
            var result = new List<Item>();
            foreach (var item in this.items)
            {
                if ((item.TypeMask & typeMask) == typeMask)
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        public int GetCountsOfItems(Item item)
        {
            return 50;
            // to do
        }

        public void RemoveNItems(Item item, int counts)
        {
            Debug.Log($"delete {counts} of {item}");
            //to do
        }
    }
}


