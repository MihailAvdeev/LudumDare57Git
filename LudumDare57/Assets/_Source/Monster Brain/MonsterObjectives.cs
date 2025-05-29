using System;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterBrainSystem
{
    [Serializable]
    public class MonsterObjectives
    {
        [field: SerializeField] public List<Transform> Route { get; private set; } = new();

        [field: Space]
        [field: SerializeField] public bool IsActive { get; private set; }
    }
}
