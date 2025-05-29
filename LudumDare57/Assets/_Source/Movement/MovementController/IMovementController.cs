using UnityEngine;

namespace MovementSystem
{
    public interface IMovementController
    {
        public void Move(Vector2 direction);
    }
}
