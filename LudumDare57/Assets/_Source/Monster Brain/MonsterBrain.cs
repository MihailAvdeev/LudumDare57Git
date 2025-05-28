using FillDisplayerSystem;
using MonsterMovementSystem;
using MonsterPerseptionSystem;
using WeaponSystem;
using StateMachineSystem;
using System;

namespace MonsterBrainSystem
{
    public class MonsterBrain
    {
        private readonly StateMachine _stateMachine;

        public MonsterBrain(MonsterMovement movement, MonsterPerception perception, MonsterObjectives objectives, Weapon weapon, IFillDisplayer awarenessDisplayer)
        {
            if (movement == null) throw new ArgumentNullException(nameof(movement));
            if (perception is null) throw new ArgumentNullException(nameof(perception));
            if (objectives is null) throw new ArgumentNullException(nameof(objectives));


            InactiveState inactiveState = new();
            ActiveState activeState = new(movement, perception, objectives, weapon, awarenessDisplayer);

            _stateMachine = new(inactiveState);

            _stateMachine.AddTransition(inactiveState, activeState, () => objectives.IsActive);
            _stateMachine.AddTransition(activeState, inactiveState, () => !objectives.IsActive);

            _stateMachine.Enter();
        }

        public void Tick()
        {
            _stateMachine.Tick();
        }
    }
}
