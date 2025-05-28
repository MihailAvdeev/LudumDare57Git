using PerceptionSystem;
using UnityEngine;

namespace DecoySystem
{
    internal class DecoyPercievedObject : APercievedObject
    {
        [SerializeField] private float engagedVisibilityDistance;

        public bool IsPercievable { get; set; } = false;

        protected override float VisibilityDistance { get { return IsPercievable ? engagedVisibilityDistance : 0.0f; } }
    }
}
