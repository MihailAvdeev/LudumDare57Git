using MonsterMovementSystem;
using MonsterPerseptionSystem;
using WeaponSystem;
using PerceptionSystem;
using StateMachineSystem;
using System.Linq;
using UnityEngine;

namespace MonsterBrainSystem
{
    public class ChaseState : IState
    {
        private readonly MonsterMovement _movement;
        private readonly MonsterPerception _perception;
        private readonly Weapon _weapon;

        public ChaseState(MonsterMovement movement, MonsterPerception perception, Weapon weapon)
        {
            _movement = movement != null ? movement : throw new System.ArgumentNullException(nameof(movement));
            _perception = perception ?? throw new System.ArgumentNullException(nameof(perception));
            _weapon = weapon ?? throw new System.ArgumentNullException(nameof(weapon));
        }
        
        public void Enter()
        {
            Debug.Log("Chasing");

            _movement.SetAgressiveSpeed();
        }

        public void Exit()
        {
            
        }

        public void Tick()
        {
            if (_perception.PercievedObjects.Count > 0)
            {
                APercievedObject percievedObject = _perception.PercievedObjects.ToArray()[0];

                if (percievedObject != null)
                    _movement.MoveToPosition(percievedObject.transform.position);

                _weapon.Use();
            }
        }

        public bool ChaseFinished()
        {
            return _movement.ReachedEndOfPath && _perception.PercievedObjects.Count <= 0;
        }
    }
}
