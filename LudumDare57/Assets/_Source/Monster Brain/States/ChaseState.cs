using MonsterMovementSystem;
using MonsterPerseptionSystem;
using WeaponSystem;
using PerceptionSystem;
using StateMachineSystem;
using System.Linq;
using UnityEngine;
using EffectsPlayerSystem;

namespace MonsterBrainSystem
{
    public class ChaseState : IState
    {
        private readonly MonsterMovement _movement;
        private readonly MonsterPerception _perception;
        private readonly Weapon _weapon;
        private readonly IEffectPlayer _alarmEffectPlayer;

        public ChaseState(MonsterMovement movement, MonsterPerception perception, Weapon weapon, IEffectPlayer alarmEffectPlayer)
        {
            _movement = movement != null ? movement : throw new System.ArgumentNullException(nameof(movement));
            _perception = perception ?? throw new System.ArgumentNullException(nameof(perception));
            _weapon = weapon ?? throw new System.ArgumentNullException(nameof(weapon));
            _alarmEffectPlayer = alarmEffectPlayer ?? throw new System.ArgumentNullException(nameof(alarmEffectPlayer));
        }
        
        public void Enter()
        {
            Debug.Log("Chasing");

            _alarmEffectPlayer.PlayEffect();

            _movement.SetAgressiveSpeed();
        }

        public void Exit()
        {
            
        }

        public void Tick()
        {
            if (_perception.PercievedObjects.Count > 0)
            {
                APercievedObject target = SelectChaseTarget();

                if (target != null)
                    _movement.MoveToPosition(target.transform.position);

                _weapon.Use();
            }
        }

        public bool ChaseFinished()
        {
            return _movement.ReachedEndOfPath && _perception.PercievedObjects.Count == 0;
        }

        private APercievedObject SelectChaseTarget()
        {
            float lowestVisibility = 0;

            APercievedObject target = null;

            foreach (APercievedObject percievedObject in _perception.PercievedObjects)
            {
                if (percievedObject != null)
                {
                    if (percievedObject.Visibility > lowestVisibility)
                    {
                        target = percievedObject;
                        lowestVisibility = target.Visibility;
                    }
                }
            }

            return target;
        }
    }
}
