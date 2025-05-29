using System;

namespace GameSystem.GameStart
{
    public interface IGameStartController
    {
        public event Action OnGameStarted;

        public void StartGame();
    }
}
