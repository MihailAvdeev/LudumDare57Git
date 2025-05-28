using DecoySpawnerSystem;
using DecoySystem;
using UnityEngine;

namespace DecoySpawnerImplementations
{
    public class DecoySpawner : IDecoySpawner
    {
        private readonly Decoy _decoyPrefab;
        private readonly Transform _decoySpawnPoint;
        private readonly Transform _decoysRoot;

        public DecoySpawner(Decoy decoyPrefab, Transform decoySpawnPoint, Transform decoysRoot)
        {
            _decoyPrefab = decoyPrefab != null ? decoyPrefab : throw new System.ArgumentNullException(nameof(decoyPrefab));
            _decoySpawnPoint = decoySpawnPoint != null ? decoySpawnPoint : throw new System.ArgumentNullException(nameof(decoySpawnPoint));
            _decoysRoot = decoysRoot != null ? decoysRoot : throw new System.ArgumentNullException(nameof(decoysRoot));
        }

        public Decoy SpawnDecoy()
        {
            return Object.Instantiate(_decoyPrefab, _decoySpawnPoint.position, Quaternion.identity, _decoysRoot);
        }
    }
}
