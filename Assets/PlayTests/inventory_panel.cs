using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayTests
{
    public class inventory_panel
    {
        [Test]
        public void has_25_slots()
        {
            var inventoryPanel = GetInventoryPanel();
            
            Assert.AreEqual(25, inventoryPanel.SlotCount);
        }

        [Test]
        public void bound_to_empty_inventory_has_all_slots_empty()
        {
            var inventoryPanel = GetInventoryPanel();
            var inventory = GetInventory(0);

            inventoryPanel.Bind(inventory);
            
            Assert.IsTrue(inventoryPanel.Slots.All(slot => slot.IsEmpty));
        }

        [Test]
        public void bound_to_inventory_fills_slot_for_each_item([NUnit.Framework.Range(0, 25)] int numberOfItems)
        {
            var inventoryPanel = GetInventoryPanel();
            var inventory = GetInventory(numberOfItems);

            foreach (var slot in inventoryPanel.Slots)
            {
                Assert.IsTrue(slot.IsEmpty);
            }
            
            inventoryPanel.Bind(inventory);
            for (int i = 0; i < inventoryPanel.SlotCount; i++)
            {
                bool shouldBeEmpty = i >= numberOfItems;
                Assert.AreEqual(shouldBeEmpty, inventoryPanel.Slots[i].IsEmpty);
            }
        }

        private Item GetItem()
        {
            var itemGameObject = new GameObject("Item", typeof(SphereCollider));
            return itemGameObject.AddComponent<Item>();
        }
        private Inventory GetInventory(int numberOfItems)
        {
            var inventory = new GameObject().AddComponent<Inventory>();
            for (int i = 0; i < numberOfItems; i++)
            {
                var item = GetItem();
                inventory.Pickup(item);
            }

            return inventory;
        }

        private UIInventoryPanel GetInventoryPanel()
        {
            var prefab = AssetDatabase.LoadAssetAtPath<UIInventoryPanel>("Assets/Prefabs/UI/InventoryPanel.prefab");
            return Object.Instantiate(prefab);
        }
    }
}