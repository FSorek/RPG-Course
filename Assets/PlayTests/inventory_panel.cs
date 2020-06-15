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
            var inventory = GetInventory();

            inventoryPanel.Bind(inventory);
            
            Assert.IsTrue(inventoryPanel.Slots.All(slot => slot.IsEmpty));
        }

        [Test]
        public void bound_to_inventory_with_one_item_fills_only_first_slot()
        {
            var inventoryPanel = GetInventoryPanel();
            var inventory = GetInventory();
            var item = GetItem();
            inventory.Pickup(item);
            
            Assert.IsTrue(inventoryPanel.Slots[0].IsEmpty);
            inventoryPanel.Bind(inventory);
            Assert.IsFalse(inventoryPanel.Slots[0].IsEmpty);
        }

        private Item GetItem()
        {
            var itemGameObject = new GameObject("Item", typeof(SphereCollider));
            return itemGameObject.AddComponent<Item>();
        }
        private Inventory GetInventory()
        {
            return new GameObject().AddComponent<Inventory>();
        }

        private UIInventoryPanel GetInventoryPanel()
        {
            var prefab = AssetDatabase.LoadAssetAtPath<UIInventoryPanel>("Assets/Prefabs/UI/InventoryPanel.prefab");
            return Object.Instantiate(prefab);
        }
    }
}