using System.Collections.Generic;
using UnityEngine;

namespace CountDisplayerSystem
{
    public class MBSpawnerCountDisplayer : AMBCountDisplayer
    {
        [SerializeField] private GameObject spawnedObjectPrefab;
        [SerializeField] private Transform spawnedObjectsRoot;

        private readonly Stack<GameObject> _spawnedObjects = new();

        public override void DisplayCount(int count)
        {
            if (count < 0)
                count = 0;

            if (count > _spawnedObjects.Count)
                count = _spawnedObjects.Count;

            if (count > _spawnedObjects.Count)
            {
                for (int i = 0; i < count - _spawnedObjects.Count; i++)
                {
                    GameObject spawnedObject = Instantiate(spawnedObjectPrefab, spawnedObjectsRoot);
                    _spawnedObjects.Push(spawnedObject);
                }
            }
            else if (count < _spawnedObjects.Count)
            {
                for (int i = 0; i < _spawnedObjects.Count - count; i++)
                {
                    if (_spawnedObjects.TryPop(out GameObject spawnedObject))
                        Destroy(spawnedObject);
                }
            }
        }
    }
}
