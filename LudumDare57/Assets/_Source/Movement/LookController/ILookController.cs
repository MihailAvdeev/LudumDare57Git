using UnityEngine;

namespace MovementSystem
{
    public interface ILookController
    {
        public void LookAt(Vector2 mouseScreenPosition);
    }
}
