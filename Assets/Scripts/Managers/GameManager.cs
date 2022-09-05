using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

namespace StackRider
{
    public class GameManager : Singleton<GameManager>
    {
        public GameState state = GameState.Idle;
        
        public int numberOfGemsCollected = 0;
        
        [SerializeField] private GameObject playerObj;

        [SerializeField] private float restartLevelWaitSecond;
        [SerializeField] private float passLevelWaitSecond;
        
        private LevelManager _levelManager;
        
        protected override void Awake()
        {
            numberOfGemsCollected = PlayerPrefs.GetInt(TagLayerData.GEM);
            _levelManager = LevelManager.Instance;
        }
        public void OnStart()
        {
            state = GameState.Playing;
            playerObj.SetActive(true);
        }

        public void AddGem(int collected)
        {
            numberOfGemsCollected += collected;
            PlayerPrefs.SetInt(TagLayerData.GEM, numberOfGemsCollected);
        }

        public void Fail()
        {
            state = GameState.Failed;
            StartCoroutine(_levelManager.RestartLevelAfterWait(restartLevelWaitSecond));
        }

        public void Success()
        {
            state = GameState.Success;
            StartCoroutine(_levelManager.PassLevelAfterWait(passLevelWaitSecond));
        }
    }

    public enum GameState
    {
        Idle,
        Success,
        Failed,
        Playing
    }
}



