using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace a_player
{
    public class moving_into_an_item
    {
        private Player player;
        private Item item;

        [UnitySetUp]
        public IEnumerator init()
        {
            yield return Helpers.LoadItemsTestsScene();
            player = Helpers.GetPlayer();

            player.PlayerInput.Vertical.Returns(1f);
            
            item = Object.FindObjectOfType<Item>();
        }
        
        [UnityTest]
        public IEnumerator picks_up_and_equips_item()
        {
            Assert.AreNotSame(item, player.GetComponent<Inventory>().ActiveItem);
            yield return new WaitForSeconds(1f);
            Assert.AreSame(item, player.GetComponent<Inventory>().ActiveItem);
        }
        
        [UnityTest]
        public IEnumerator changes_crosshair_to_item_crosshair()
        {
            var crosshair = Object.FindObjectOfType<Crosshair>();
            
            Assert.AreNotSame(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);
            item.transform.position = player.transform.position;
            yield return null;
            Assert.AreSame(item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);
        }
        
        [UnityTest]
        public IEnumerator changes_slot_1_icon_to_match_item_icon()
        {
            var hotbar = Object.FindObjectOfType<Hotbar>();
            var slotOne = hotbar.GetComponentInChildren<Slot>();
            
            Assert.AreNotSame(item.Icon, slotOne.IconImage.sprite);
            item.transform.position = player.transform.position;
            yield return new WaitForFixedUpdate();
            Assert.AreSame(item.Icon, slotOne.IconImage.sprite);
        }
    }
}