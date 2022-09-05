using System;
using System.Collections.Generic;
using StackRider.Collectibles;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StackRider
{
    public class StackManager : Singleton<StackManager>
    {
        [Header("Player Models")]
        [SerializeField] private Transform mainBall;
        [SerializeField] private Transform character;
        
        [Header("Ball Containers")]
        [SerializeField] private Transform stackedBallsContainer;
        [SerializeField] private Transform freeBallsContainer;

        [Header("Stack")] 
        [SerializeField] private float ballRotationSpeed; 
        public int maxStackAmount = 20;

        private float _distanceBetweenBalls;
        private List<Transform> _stack = new List<Transform>();
        public int NumberOfBalls => _stack.Count;

        private GameManager _gameManager;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            _distanceBetweenBalls = mainBall.localScale.y;
            _stack.Add(mainBall);
        }

        private void Update()
        {
            RotateBallsOnStack();
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
                _gameManager.Fail();
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
    }
}


