using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyController : MonoBehaviour, IPerciever
    {
        public List<Transform> route = new();
        private int _currentRouteIndex = -1;

        [SerializeField] private EnemyMovement enemyMovement;

        // Perception
        private readonly List<PercievedObject> _percievedObjects = new();
        private PercievedObject _currentPercievedObject;

        // Weapon
        [Space]
        [SerializeField] private MeleeWeapon.WeaponReferences weaponReferences;
        [SerializeField] private MeleeWeapon.WeaponParameters weaponParameters;

        private MeleeWeapon _weapon;

        private void Start()
        {
            enemyMovement.OnEndOfPathReached += SelectNextTarget;

            _weapon = new(weaponReferences, weaponParameters);

            SelectNextTarget();
        }

        private void FixedUpdate()
        {
            if (_currentPercievedObject != null && !_percievedObjects.Contains(_currentPercievedObject))
            {
                _currentPercievedObject = null;
            }

            if (_currentPercievedObject == null && _percievedObjects.Count > 0)
            {
                _currentPercievedObject = _percievedObjects[0];
            }

            if (_currentPercievedObject != null)
            {
                enemyMovement.MoveToPosition(_currentPercievedObject.transform.position);
            }

            _weapon.Use();
        }

        public void StartPercieving(PercievedObject percievedObject)
        {
            _percievedObjects.Add(percievedObject);
        }

        public void StopPercieving(PercievedObject percievedObject)
        {
            _percievedObjects.Remove(percievedObject);
        }

        private void SelectNextTarget()
        {
            if (_currentPercievedObject != null)
                return;

            _currentRouteIndex++;

            if (_currentRouteIndex >= route.Count)
            {
                _currentRouteIndex = 0;
            }

            enemyMovement.MoveToPosition(route[_currentRouteIndex].position);
        }
    }
}
