using System;
using StackRider;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
        SetText(gemCountText,(_gameManager.numberOfGemsCollected + _levelManager.collectedGems).ToString());
        SetText(levelCountText, TagLayerData.LEVEL + " " + (_levelManager.levelIndex).ToString());
    }
    private void SetText(TextMeshProUGUI tmp, string message)
    {
        tmp.text = message;
    }


}
