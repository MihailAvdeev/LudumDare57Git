using System.Collections.ObjectModel;
using UnityEngine;

namespace MovingObjectSystem
{
    public abstract class AWaypointsProvider : MonoBehaviour
    {
        public abstract ReadOnlyCollection<Vector3> Waypoints { get; }
    }
}
