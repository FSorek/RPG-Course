using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class a_moving_cube
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator moving_forward_changes_position()
        {
            // ARRANGE
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            
            for (int i = 0; i < 10; i++)
            {
                // ACT
                cube.transform.position += Vector3.forward;
                yield return null;
                
                // ASSERT
                Assert.AreEqual(i+1, cube.transform.position.z);
            }
        }
    }
}
