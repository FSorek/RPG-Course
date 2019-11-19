using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace a_player
{
    public class with_positive_vertical_input
    {
        [UnityTest]
        public IEnumerator moves_forward()
        {
            var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(50, 0.1f, 50);
            floor.transform.position = Vector3.zero;

            var playerGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerGO.AddComponent<CharacterController>();
            playerGO.transform.position = new Vector3(0, 5f, 0);
            
            Player player = playerGO.AddComponent<Player>();
            
            var testPlayerInput = Substitute.For<IPlayerInput>();
            player.PlayerInput = testPlayerInput;
            
            testPlayerInput.Vertical.Returns(1f);

            float startingZPos = player.transform.position.z;
            
            yield return new WaitForSeconds(2f);

            float endingZPos = player.transform.position.z;
            
            Assert.Greater(endingZPos, startingZPos);
        }

        public class with_positive_horizontal_input
        {
            [UnityTest]
            public IEnumerator moves_right()
            {
                var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floor.transform.localScale = new Vector3(50, 0.1f, 50);
                floor.transform.position = Vector3.zero;

                var playerGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                playerGO.AddComponent<CharacterController>();
                playerGO.transform.position = new Vector3(0, 5f, 0);
            
                Player player = playerGO.AddComponent<Player>();
                
                var testPlayerInput = Substitute.For<IPlayerInput>();
                player.PlayerInput = testPlayerInput;
                
                player.PlayerInput.Horizontal.Returns(1f);

                float startingXPos = player.transform.position.x;
            
                yield return new WaitForSeconds(2f);

                float endingXPos = player.transform.position.x;
            
                Assert.Greater(endingXPos, startingXPos);
            }
        }
    }
}