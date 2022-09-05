using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StackRider
{
    public class LevelManager : Singleton<LevelManager>
    {
        [Header("Level Data")]
        public int collectedGems;

        [Header("Level Management")] 
        public int levelIndex;
        [SerializeField] private List<GameObject> levels;
        
        
        private GameManager _gameManager;
        protected override void Awake()
        {
            LevelInit();
            _gameManager = GameManager.Instance;
        }

        private void LevelInit()
        {
            levelIndex = PlayerPrefs.GetInt(TagLayerData.LEVEL);

            if (levelIndex >= levels.Count)
            {
                levelIndex = 0;
                PlayerPrefs.SetInt(TagLayerData.LEVEL, levelIndex);
            }
            
            GameObject activeLevel = Instantiate(levels[levelIndex], Vector3.zero, Quaternion.identity);
        }

        public IEnumerator RestartLevelAfterWait(float seconds)
        { 
            yield return new WaitForSeconds (seconds);
            
            collectedGems = 0;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
            
            _gameManager.state = GameState.Playing;
        }

        public IEnumerator PassLevelAfterWait(float seconds)
        {
            yield return new WaitForSeconds (seconds);
            
            _gameManager.AddGem(collectedGems);
            collectedGems = 0;
            
            PlayerPrefs.SetInt(TagLayerData.LEVEL, levelIndex += 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            
            _gameManager.state = GameState.Playing;
        }

        public void AddGem()
        {
            collectedGems++;
        }
    }
}

