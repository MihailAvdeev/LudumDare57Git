using MonsterMovementSystem;
using StateMachineSystem;
using UnityEngine;

namespace MonsterBrainSystem
{
    public class StillState : IState
    {
        private readonly MonsterMovement _movement;

        public StillState(MonsterMovement movement)
        {
            _movement = movement;
        }

        public void Enter()
        {
            Debug.Log("Standing");

            _movement.StopMoving();
        }

        public void Exit()
        {

        }

        public void Tick()
        {

        }
    }
}
