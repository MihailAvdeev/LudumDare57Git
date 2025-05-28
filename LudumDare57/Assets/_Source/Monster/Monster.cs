using MonsterBrainSystem;
using MonsterMovementSystem;
using PerceptionSystem;
using UnityEngine;
using MonsterPerseptionSystem;
using WeaponSystem;
using FillDisplayerSystem;

namespace MonsterSystem
{
    public class Monster : MonoBehaviour, IPerciever
    {
        [SerializeField] private MonsterMovement movement;

        [Header("Weapon")]
        [SerializeField] private Weapon.WeaponReferences weaponReferences;
        [SerializeField] private Weapon.WeaponParameters weaponParameters;

        [Space]
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private AudioClip alertSound;

        [Space]
        [SerializeField] private MonsterObjectives objectives;

        [Space]
        [SerializeField] private AMBFillDisplayer awarenessDisplayer;

        private MonsterPerception _perception;
        private MonsterBrain _brain;

        private void Start()
        {
            Weapon weapon = new(weaponReferences, weaponParameters);

            _perception = new();

            _brain = new(movement, _perception, objectives, weapon, awarenessDisplayer);
        }

        private void FixedUpdate()
        {
            _brain.Tick();
        }

        #region Perciever
        public void StartPercieving(APercievedObject percievedObject)
        {
            _perception.PercievedObjects.Add(percievedObject);
        }

        public void StopPercieving(APercievedObject percievedObject)
        {
            _perception.PercievedObjects.Remove(percievedObject);
        }
        #endregion
    }
}
