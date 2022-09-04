using UnityEngine;

namespace StackRider
{
    public class GameManager : Singleton<GameManager>
    {
        public GameState state = GameState.Playing;

        [SerializeField] private GameStatsUI gameStatsUI;
        private int _numberOfGemsCollected = 0;

        public void AddGem()
        {
            _numberOfGemsCollected++;
            gameStatsUI.SetGemText(_numberOfGemsCollected);
        }
        
    }

    public enum GameState
    {
        Idle,
        Finished,
        Failed,
        Playing
    }
}



