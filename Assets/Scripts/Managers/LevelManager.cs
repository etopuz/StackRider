using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        
        [Header("Wait Seconds")]
        [SerializeField] private float restartLevelWaitSecond;
        [SerializeField] private float passLevelWaitSecond;
        
        
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

        public IEnumerator RestartLevelAfterWait()
        { 
            _gameManager.state = GameState.Failed;
            yield return new WaitForSeconds (restartLevelWaitSecond);
            
            collectedGems = 0;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
            
            _gameManager.Play();
        }

        public IEnumerator PassLevelAfterWait()
        {
            _gameManager.state = GameState.Success;

            yield return new WaitForSeconds (passLevelWaitSecond);
            
            _gameManager.AddGem(collectedGems);
            collectedGems = 0;
            
            PlayerPrefs.SetInt(TagLayerData.LEVEL, levelIndex += 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            
            _gameManager.Play();
        }

        public void AddGem()
        {
            collectedGems++;
        }
    }
}

