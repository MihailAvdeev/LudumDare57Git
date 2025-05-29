using MonsterMovementSystem;
using StateMachineSystem;
using System;
using UnityEngine;

namespace MonsterBrainSystem
{
    public class PatrolState : IState
    {
        private readonly MonsterObjectives _objectives;
        private readonly MonsterMovement _movement;

        private int _nextWaypointIndex;

        public PatrolState(MonsterMovement movement, MonsterObjectives objectives)
        {
            _movement = movement != null ? movement : throw new ArgumentNullException(nameof(movement));
            _objectives = objectives ?? throw new ArgumentNullException(nameof(objectives));
        }

        public void Enter()
        {
            Debug.Log("Patroling");

            _movement.SetQuiteSpeed();

            MoveToNextWaypoint();
        }

        public void Exit()
        {
            _movement.StopMoving();
        }

        public void Tick()
        {
            if (_movement.ReachedEndOfPath)
                MoveToNextWaypoint();
        }

        private void MoveToNextWaypoint()
        {
            if (_objectives.Route.Count <= 0)
                return;

            if (_nextWaypointIndex + 1 < _objectives.Route.Count)
                _nextWaypointIndex++;
            else
                _nextWaypointIndex = 0;

            Transform nextWaypoint = _objectives.Route[_nextWaypointIndex];

            if (nextWaypoint == null)
                return;

            _movement.MoveToPosition(nextWaypoint.position);
        }
    }
}
