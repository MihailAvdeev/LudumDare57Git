using DecoyInventorySystem;
using DecoySpawnerImplementations;
using DecoySystem;
using DecoyUserSystem;
using UnityEngine;

namespace DecoyUserSystem
{
    public class MBDecoySpawnerUser : MonoBehaviour, IDecoyUser
    {
        [Header("Inventory")]
        [SerializeField] private MBDecoyInventory decoyInventory;

        [Header("Spawner")]
        [SerializeField] private Decoy decoyPrefab;
        [SerializeField] private Transform decoysRoot;

        private DecoyUser _decoyUser;

        private DecoyUser DecoyUser
        {
            get
            {
                _decoyUser ??= new(decoyInventory, new DecoySpawner(decoyPrefab, transform, decoysRoot));

                return _decoyUser;
            }
        }

        public void UseDecoy()
        {
            DecoyUser.UseDecoy();
        }
    }
}