using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StackRider.Obstacles
{
    public class StaticObstacle : MonoBehaviour, IObstacle
    {
        private float _obstacleSize;

        private void Start()
        {
            _obstacleSize = transform.localScale.y;
        }
        
        public void DropBalls()
        {
            StackManager.Instance.Drop(_obstacleSize);
        }
    }
}
