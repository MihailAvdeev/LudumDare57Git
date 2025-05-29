using PerceptionSystem;
using System.Collections.Generic;

namespace MonsterPerseptionSystem
{
    public class MonsterPerception
    {
        public HashSet<APercievedObject> PercievedObjects { get; } = new();
    }
}
