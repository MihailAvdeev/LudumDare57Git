using System;

namespace GameSystem.GameLoss
{
    public interface IGameLossController
    {
        public event Action OnGameLost;

        public void LoseGame();
    }
}
