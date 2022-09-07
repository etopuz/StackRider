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
        
        public GameObject playerObj;

        protected override void Awake()
        {
            numberOfGemsCollected = PlayerPrefs.GetInt(TagLayerData.GEM);
        }
        public void OnStart()
        {
            Play();
        }

        public void Play()
        {
            state = GameState.Playing;
            playerObj.SetActive(true);
        }

        public void AddGem(int collected)
        {
            numberOfGemsCollected += collected;
            PlayerPrefs.SetInt(TagLayerData.GEM, numberOfGemsCollected);
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



