using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

namespace a_player
{
    public class with_positive_vertical_input
    {
        public static class Helpers
        {
            public static void CreateFloor()
            {
                var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floor.transform.localScale = new Vector3(50, 0.1f, 50);
                floor.transform.position = Vector3.zero;
            }

            public static Player CreatePlayer()
            {
                var playerGO = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                playerGO.AddComponent<CharacterController>();
                playerGO.AddComponent<NavMeshAgent>();
                playerGO.transform.position = new Vector3(0, 5f, 0);
            
                Player player = playerGO.AddComponent<Player>();
            
                var testPlayerInput = Substitute.For<IPlayerInput>();
                player.PlayerInput = testPlayerInput;

                return player;
            }

            public static float CalculateTurn(Quaternion originalRotation, Quaternion transformRotation)
            {
                var cross = Vector3.Cross(originalRotation * Vector3.forward, transformRotation * Vector3.forward);
                var dot = Vector3.Dot(cross, Vector3.up);
                return dot;
            }
        }
        [UnityTest]
        public IEnumerator moves_forward()
        {
            Helpers.CreateFloor();
            var player = Helpers.CreatePlayer();
            
            player.PlayerInput.Vertical.Returns(1f);

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
                Helpers.CreateFloor();
                var player = Helpers.CreatePlayer();
                
                player.PlayerInput.Horizontal.Returns(1f);

                float startingXPos = player.transform.position.x;
            
                yield return new WaitForSeconds(2f);

                float endingXPos = player.transform.position.x;
            
                Assert.Greater(endingXPos, startingXPos);
            }
        }

        public class with_negative_mouse_x
        {
            [UnityTest]
            public IEnumerator turns_left()
            {
                Helpers.CreateFloor();
                var player = Helpers.CreatePlayer();

                player.PlayerInput.MouseX.Returns(-1f);
                var originalRotation = player.transform.rotation;
                
                yield return new WaitForSeconds(0.5f);

                float turnAmount = Helpers.CalculateTurn(originalRotation, player.transform.rotation);
                Assert.Less(turnAmount, 0);
            }
        }
    }
}