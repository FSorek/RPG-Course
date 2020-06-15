using System.Collections;
using a_player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace state_machine
{
    public class entity_state_machine
    {
        [UnityTest] 
        public IEnumerator starts_in_idle_state()
        { 
            yield return Helpers.LoadEntityStateMachineTestsScene();
            var stateMachine = Object.FindObjectOfType<EntityStateMachine>();
            
            Assert.AreEqual(typeof(Idle), stateMachine.CurrentStateType);
        }
        
        [UnityTest] 
        public IEnumerator switches_to_chase_player_state_when_in_chase_range()
        { 
            yield return Helpers.LoadEntityStateMachineTestsScene();

            var player = Helpers.GetPlayer();
            var stateMachine = Object.FindObjectOfType<EntityStateMachine>();
            
            player.transform.position = stateMachine.transform.position + new Vector3(5f, 0, 0);
            yield return null;
            Assert.AreEqual(typeof(Idle), stateMachine.CurrentStateType);
            
            player.transform.position = stateMachine.transform.position + new Vector3(4.99f, 0, 0);
            yield return null;
            Assert.AreEqual(typeof(ChasePlayer), stateMachine.CurrentStateType);
        }
        
        [UnityTest] 
        public IEnumerator switches_to_dead_state_once_health_reaches_zero()
        { 
            yield return Helpers.LoadEntityStateMachineTestsScene();

            var stateMachine = Object.FindObjectOfType<EntityStateMachine>();
            var entity = stateMachine.GetComponent<Entity>();
            
            yield return null;
            Assert.AreEqual(typeof(Idle), stateMachine.CurrentStateType);
            
            entity.TakeHit(entity.Health - 1);
            yield return null;
            Assert.AreEqual(typeof(Idle), stateMachine.CurrentStateType);
            
            entity.TakeHit(entity.Health);
            yield return null;
            Assert.AreEqual(typeof(Dead), stateMachine.CurrentStateType);
        }
    }
}