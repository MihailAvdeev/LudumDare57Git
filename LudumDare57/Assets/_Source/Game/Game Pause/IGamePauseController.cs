using System;

namespace GameSystem.Pause
{
    public interface IGamePauseController
    {
        public bool IsPaused { get; }

        public event Action OnGamePaused;
        public event Action OnGameUnpaused;

        public void PauseGame();

        public void UnpauseGame();
    }
}
