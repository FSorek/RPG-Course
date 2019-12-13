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
        [UnityTest]
        public IEnumerator picks_up_and_equips_item()
        {
            yield return Helpers.LoadItemsTestsScene();
            var player = Helpers.GetPlayer();

            player.PlayerInput.Vertical.Returns(1f);
            
            Item Item = Object.FindObjectOfType<Item>();
            
            Assert.AreNotSame(Item, player.GetComponent<Inventory>().ActiveItem);
            yield return new WaitForSeconds(1f);

            Assert.AreSame(Item, player.GetComponent<Inventory>().ActiveItem);
        }
        
        [UnityTest]
        public IEnumerator changes_crosshair_to_item_crosshair()
        {
            yield return Helpers.LoadItemsTestsScene();
            var player = Helpers.GetPlayer();
            var crosshair = Object.FindObjectOfType<Crosshair>();
            
            Item Item = Object.FindObjectOfType<Item>();
            
            Assert.AreNotSame(Item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);

            Item.transform.position = player.transform.position;
            yield return null;

            Assert.AreSame(Item.CrosshairDefinition.Sprite, crosshair.GetComponent<Image>().sprite);
        }
    }
}