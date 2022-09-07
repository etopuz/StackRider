using System;
using StackRider;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace StackRider.UI{
    public class GameStatsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI gemCountText;
        [SerializeField] private TextMeshProUGUI levelCountText;

        private GameManager _gameManager;
        private LevelManager _levelManager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _levelManager = LevelManager.Instance;
        }

        private void Update()
        {
            levelCountText.SetText(_levelManager.levelIndex, "LEVEL ", null);
            gemCountText.SetText(_gameManager.numberOfGemsCollected + _levelManager.collectedGems);
        }
        
    }
}

