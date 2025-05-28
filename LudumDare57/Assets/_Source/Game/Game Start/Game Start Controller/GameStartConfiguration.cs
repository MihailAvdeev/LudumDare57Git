using System;
using UnityEngine;

namespace GameSystem.GameStart
{
    [Serializable]
    public class GameStartConfiguration
    {
        [field: SerializeField] public int StartOxygen { get; private set; }
        [field: SerializeField] public int StartFlashlightMode { get; private set; }
    }
}
