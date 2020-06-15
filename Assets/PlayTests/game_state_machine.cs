using System.Collections;
using a_player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace state_machine
{
    public class game_state_machine
    {
        [TearDown]
        public void teardown()
        {
            Object.Destroy(Object.FindObjectOfType<GameStateMachine>());
        }
        
        [UnityTest]
        public IEnumerator switches_to_loading_when_level_to_load_selected()
        {
            yield return Helpers.LoadMenuScene();
            var statemachine = Object.FindObjectOfType<GameStateMachine>();
            
            Assert.AreEqual(typeof(Menu), statemachine.CurrentStateType);
            PlayButton.LevelToLoad = "Level1";
            yield return null;
            
            Assert.AreEqual(typeof(LoadLevel), statemachine.CurrentStateType);
        }
        
        [UnityTest]
        public IEnumerator switches_to_play_when_level_to_load_completed()
        {
            yield return Helpers.LoadMenuScene();
            var statemachine = Object.FindObjectOfType<GameStateMachine>();
            
            Assert.AreEqual(typeof(Menu), statemachine.CurrentStateType);
            PlayButton.LevelToLoad = "Level1";
            yield return null;
            
            Assert.AreEqual(typeof(LoadLevel), statemachine.CurrentStateType);
            
            yield return new WaitUntil(() => statemachine.CurrentStateType == typeof(Play));
            Assert.AreEqual(typeof(Play), statemachine.CurrentStateType);
        }

        [UnityTest]
        public IEnumerator only_allows_one_instance_to_exist()
        {
            var firstGameStateMachine = new GameObject("FirstStateMachine").AddComponent<GameStateMachine>();
            var secondGameStateMachine = new GameObject("FirstStateMachine").AddComponent<GameStateMachine>();
            yield return null;
            
            Assert.IsTrue(firstGameStateMachine != null);
            Assert.IsTrue(secondGameStateMachine == null);
        }
    }
}