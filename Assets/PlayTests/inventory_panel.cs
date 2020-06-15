using System.Collections;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayTests
{
    public class ui_inventory_slot
    {
        [Test]
        public void when_item_is_set_changes_icon_to_match()
        {
            var inventoryPanel = inventory_panel.GetInventoryPanel();
            var slot = inventoryPanel.Slots[0];
            var item = Substitute.For<IItem>();
            var sprite = Sprite.Create(Texture2D.redTexture, new Rect(0, 0, 4, 4), Vector2.zero);

            item.Icon.Returns(sprite);
            slot.SetItem(item);
            
            Assert.AreSame(sprite, slot.Icon);
        }
    }
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

        [Test]
        public void places_item_in_slot_when_item_is_added_to_inventory()
        {
            var inventoryPanel = GetInventoryPanel();
            var inventory = GetInventory();
            var item = GetItem();
            
            inventoryPanel.Bind(inventory);
            
            Assert.IsTrue(inventoryPanel.Slots[0].IsEmpty);
            
            inventory.Pickup(item);
            
            Assert.IsFalse(inventoryPanel.Slots[0].IsEmpty);
        }

        [Test]
        public void bound_to_null_inventory_has_empty_slots()
        {
            var inventoryPanel = GetInventoryPanel();
            inventoryPanel.Bind(null);
            
            Assert.IsTrue(inventoryPanel.Slots.All(slot => slot.IsEmpty));
        }
        
        [Test]
        public void bound_to_valid_inventory_then_bound_to_null_inventory_has_empty_slots()
        {
            var inventoryPanel = GetInventoryPanel();
            var inventory = GetInventory(1);
            
            inventoryPanel.Bind(inventory);
            inventoryPanel.Bind(null);
            
            Assert.IsTrue(inventoryPanel.Slots.All(slot => slot.IsEmpty));
        }

        private Item GetItem()
        {
            var itemGameObject = new GameObject("Item", typeof(SphereCollider));
            return itemGameObject.AddComponent<Item>();
        }
        private Inventory GetInventory(int numberOfItems = 0)
        {
            var inventory = new GameObject().AddComponent<Inventory>();
            for (int i = 0; i < numberOfItems; i++)
            {
                var item = GetItem();
                inventory.Pickup(item);
            }

            return inventory;
        }

        public static UIInventoryPanel GetInventoryPanel()
        {
            var prefab = AssetDatabase.LoadAssetAtPath<UIInventoryPanel>("Assets/Prefabs/UI/InventoryPanel.prefab");
            return Object.Instantiate(prefab);
        }
    }
}