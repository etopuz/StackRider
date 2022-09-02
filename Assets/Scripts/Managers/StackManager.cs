using System;
using System.Collections.Generic;
using StackRider.Collectibles;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StackRider
{
    public class StackManager : Singleton<StackManager>
    {
        [Header("References")]
        [SerializeField] private Transform mainBall;
        [SerializeField] private Transform stackedBallsContainer;
        [SerializeField] private Transform freeBallsContainer;

        public float moveForward = 0f;
        
        private float _distanceBetweenBalls;
    
        private List<Transform> _stack = new List<Transform>();

        private void Start()
        {
            _distanceBetweenBalls = mainBall.localScale.y;
            _stack.Add(mainBall);
            
        }

        private void Update()
        {
            RotateBallsOnStack();
            moveForward = (_stack.Count % 2 == 0) ? 1f : -1f;
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
        }

        public void Drop(float obstacleSize)
        {
            int numberOfDroppedBalls = (int) (obstacleSize / _distanceBetweenBalls);
            int removeIndex = _stack.Count - 1;
            if (numberOfDroppedBalls > removeIndex)
            {
                GameManager.Instance.state = GameState.Failed;
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

        public void RotateBallsOnStack()
        {
            
        }
    }
}


