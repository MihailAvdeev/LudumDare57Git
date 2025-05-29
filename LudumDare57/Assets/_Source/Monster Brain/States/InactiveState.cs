using StateMachineSystem;
using UnityEngine;

namespace MonsterBrainSystem
{
    public class InactiveState : IState
    {
        public InactiveState()
        {

        }

        public void Enter()
        {
            Debug.Log("Inactive");
        }

        public void Exit()
        {

        }

        public void Tick()
        {

        }
    }
}
