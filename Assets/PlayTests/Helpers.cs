using System.Collections;
using NSubstitute;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace a_player
{
    public static class Helpers
    {
        public static IEnumerator LoadMovementTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("MovementTests");
            while (operation.isDone == false)
                yield return null;
                
            var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(50, 0.1f, 50);
            floor.transform.position = Vector3.zero;
        }
        
        public static IEnumerator LoadItemsTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("ItemTests");
            while (operation.isDone == false)
                yield return null;
                
            operation = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            while (operation.isDone == false)
                yield return null;
        }

        public static Player GetPlayer()
        {
            Player player = GameObject.FindObjectOfType<Player>();
            return player;
        }

        public static float CalculateTurn(Quaternion originalRotation, Quaternion transformRotation)
        {
            var cross = Vector3.Cross(originalRotation * Vector3.forward, transformRotation * Vector3.forward);
            var dot = Vector3.Dot(cross, Vector3.up);
            return dot;
        }

        public static IEnumerator LoadEntityStateMachineTestsScene()
        {
            var operation = SceneManager.LoadSceneAsync("EntityStateMachineTests");
            while (operation.isDone == false)
                yield return null;
        }

        public static IEnumerator LoadMenuScene()
        {
            var operation = SceneManager.LoadSceneAsync("Menu");
            while (operation.isDone == false)
                yield return null;
        }
    }
}