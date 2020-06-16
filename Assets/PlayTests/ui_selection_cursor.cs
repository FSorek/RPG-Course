using NUnit.Framework;
using UnityEngine.UI;

namespace PlayTests
{
    public class ui_selection_cursor
    {
        [Test]
        public void in_default_state_shows_no_icon()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(1);
            var uiCursor = inventory_helpers.GetSelectionCursor();
            Assert.IsFalse(uiCursor.IconVisible);
            Assert.IsFalse(uiCursor.GetComponent<Image>().enabled);
        }
        
        [Test]
        public void with_item_selected_shows_item_icon()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(1);
            var uiCursor = inventory_helpers.GetSelectionCursor();
            inventoryPanel.Slots[0].OnPointerClick(null);
            Assert.IsTrue(uiCursor.IconVisible);
        }

        [Test]
        public void when_item_selected_sets_icon_image_to_correct_sprite()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(1);
            var uiCursor = inventory_helpers.GetSelectionCursor();
            inventoryPanel.Slots[0].OnPointerClick(null);
            Assert.AreSame(inventoryPanel.Slots[0].Icon, uiCursor.Icon);
        }
        
        [Test]
        public void when_item_is_unselected_set_icon_to_not_visible()
        {
            var inventoryPanel = inventory_helpers.GetInventoryPanelWithItems(1);
            var uiCursor = inventory_helpers.GetSelectionCursor();
            
            Assert.IsFalse(uiCursor.IconVisible);
            inventoryPanel.Slots[0].OnPointerClick(null);
            Assert.IsTrue(uiCursor.IconVisible);
            inventoryPanel.Slots[0].OnPointerClick(null);
            Assert.IsFalse(uiCursor.IconVisible);
        }
    }
}