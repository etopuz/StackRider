using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using StackRider.Collectibles;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StackRider
{
    public class StackManager : Singleton<StackManager>
    {
        public int NumberOfBalls => _stack.Count;
        
        [Header("Player Models")]
        [SerializeField] private Transform mainBall;
        [SerializeField] private Transform character;
        
        [Header("Ball Containers")]
        [SerializeField] private Transform stackedBallsContainer;
        [SerializeField] private Transform freeBallsContainer;

        [Header("Stack")] 
        [SerializeField] private float ballDroppingTimeWhenSuccess;
        [SerializeField] private float ballRotationSpeed; 
        public int maxStackAmount = 20;
        
        private float passedTimeInBetweenBallDrops;
        private float _distanceBetweenBalls;
        private List<Transform> _stack = new List<Transform>();

        private GameManager _gameManager;
        private LevelManager _levelManager;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            _levelManager = LevelManager.Instance;
            _distanceBetweenBalls = mainBall.localScale.y;
            _stack.Add(mainBall);
        }

        private void Update()
        {
            switch (_gameManager.state)
            {
                case GameState.Playing:
                    RotateBallsOnStack();
                    break;
                
                case GameState.Success when NumberOfBalls > 0:
                    DropBallsWhenSuccess();
                    break;
            }
        }

        public void Pickup(Transform ball)
        {
            ball.transform.SetParent(stackedBallsContainer);
            _stack.Add(ball);
            ShiftStack();
        }

        private void ShiftStack()
        {
            for (int i = 0; i < _stack.Count; i++)
            {
                _stack[i].localPosition = new Vector3(0, (_stack.Count - i  - 1) * _distanceBetweenBalls, 0);
            }

            character.localPosition = new Vector3(0, mainBall.localPosition.y + _distanceBetweenBalls/2, 0);
        }

        public void Drop(float obstacleSize)
        {
            int numberOfDroppedBalls = (int) (obstacleSize / _distanceBetweenBalls);
            int removeIndex = _stack.Count - 1;
            if (numberOfDroppedBalls > removeIndex)
            {
                StartCoroutine(_levelManager.RestartLevelAfterWait());
            }

            else
            {
                for (int i = 0; i < numberOfDroppedBalls; i++)
                {
                    _stack[removeIndex].gameObject.layer = 1;
                    _stack[removeIndex].SetParent(freeBallsContainer);
                    _stack.RemoveAt(removeIndex);
                    removeIndex--;
                }
                ShiftStack();
            }
        }

        private void RotateBallsOnStack()
        {
            int rotateDirection = 1;
            for (int i = _stack.Count - 1; i >= 0; i--)
            {
                _stack[i].Rotate(rotateDirection * ballRotationSpeed * Time.deltaTime, 0f,0f);
                rotateDirection *= -1;
            }
        }

        public void DropBallsWhenSuccess()
        {
            passedTimeInBetweenBallDrops += Time.deltaTime;
            
            if (passedTimeInBetweenBallDrops >= ballDroppingTimeWhenSuccess)
            {
                passedTimeInBetweenBallDrops = 0f;
                _stack[^1].gameObject.SetActive(false);
                _stack.RemoveAt(NumberOfBalls - 1);
                ShiftStack();
            }

            if (NumberOfBalls == 0)
            {
                Transform player = _gameManager.playerObj.transform;
                player.localPosition = new Vector3(player.localPosition.x, 0f, player.localPosition.z);
            }
        }
        
    }
}


