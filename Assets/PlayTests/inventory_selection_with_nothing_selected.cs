using NUnit.Framework;

namespace PlayTests
{
    public class inventory_selection_with_nothing_selected
    {
        [Test]
        public void clicking_non_empty_slot_selects_slot()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(1);
            var slot = inventoryPanel.Slots[0];
            slot.OnPointerClick(null);
            Assert.AreSame(slot, inventoryPanel.Selected);
        }
        [Test]
        public void clicking_empty_slot_does_not_select_slot()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems();
            var slot = inventoryPanel.Slots[0];
            slot.OnPointerClick(null);
            Assert.IsNull(inventoryPanel.Selected);
        }
    }
    
    public class inventory_selection_with_non_empty_slot_selected
    {
        [Test]
        public void clicking_slot_moves_selected_item_to_clicked_slot()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(2);
            var slot0 = inventoryPanel.Slots[0];
            var slot1 = inventoryPanel.Slots[1];
            var item0 = slot0.Item;
            var item1 = slot1.Item;
            
            Assert.IsNotNull(item0);
            Assert.IsNotNull(item1);
            
            slot0.OnPointerClick(null);
            slot1.OnPointerClick(null);

            Assert.AreSame(item0, slot1.Item);
            Assert.AreSame(item1, slot0.Item);
        }
        
        [Test]
        public void clicking_slot_clears_selection()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(2);
            var slot0 = inventoryPanel.Slots[0];
            var slot1 = inventoryPanel.Slots[1];
            
            slot0.OnPointerClick(null);
            Assert.IsNotNull(inventoryPanel.Selected);
            slot1.OnPointerClick(null);
            Assert.IsNull(inventoryPanel.Selected);
        }
    }
}