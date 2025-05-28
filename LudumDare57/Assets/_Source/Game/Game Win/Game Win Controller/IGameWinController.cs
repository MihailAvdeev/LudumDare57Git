using System;

namespace GameSystem.GameWin
{
    public interface IGameWinController
    {
        public event Action OnGameWon;

        public void WinGame();
    }
}
