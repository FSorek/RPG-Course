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
        [UnityTest]
        public IEnumerator moves_forward()
        {
            yield return Helpers.LoadMovementTestsScene();
            var player = Helpers.GetPlayer();
            
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
                yield return Helpers.LoadMovementTestsScene();
                var player = Helpers.GetPlayer();
                
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
                yield return Helpers.LoadMovementTestsScene();
                var player = Helpers.GetPlayer();

                player.PlayerInput.MouseX.Returns(-1f);
                var originalRotation = player.transform.rotation;
                
                yield return new WaitForSeconds(0.5f);

                float turnAmount = Helpers.CalculateTurn(originalRotation, player.transform.rotation);
                Assert.Less(turnAmount, 0);
            }
        }
        
        public class with_positive_mouse_x
        {
            [UnityTest]
            public IEnumerator turns_left()
            {
                yield return Helpers.LoadMovementTestsScene();
                var player = Helpers.GetPlayer();

                player.PlayerInput.MouseX.Returns(1f);
                var originalRotation = player.transform.rotation;
                
                yield return new WaitForSeconds(0.5f);

                float turnAmount = Helpers.CalculateTurn(originalRotation, player.transform.rotation);
                Assert.Greater(turnAmount, 0);
            }
        }
        
    }
}