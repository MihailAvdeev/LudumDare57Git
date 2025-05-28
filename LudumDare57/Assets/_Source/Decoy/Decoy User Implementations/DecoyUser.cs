using DecoyInventorySystem;
using DecoySpawnerSystem;
using DecoySystem;
using DecoyUserSystem;
using System;
using UnityEngine;

namespace DecoyUserSystem
{
    public class DecoyUser : IDecoyUser
    {
        private readonly IDecoyInventory _decoyInventory;
        private readonly IDecoySpawner _decoySpawner;

        public DecoyUser(IDecoyInventory decoyInventory, IDecoySpawner decoySpawner)
        {
            _decoyInventory = decoyInventory ?? throw new ArgumentNullException(nameof(decoyInventory));
            _decoySpawner = decoySpawner ?? throw new ArgumentNullException(nameof(decoySpawner));
        }

        public void UseDecoy()
        {
            if (_decoyInventory.StoredDecoysCount <= 0)
            {
                Debug.Log("No decoys to use!");
                return;
            }

            _decoyInventory.StoredDecoysCount--;
            Decoy decoy = _decoySpawner.SpawnDecoy();
            decoy.Engage();
        }
    }
}
