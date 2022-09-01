using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StackRider.Obstacles
{
    public class StaticObstacle : MonoBehaviour, IObstacle
    {
        private int _obstacleScale;

        private void Start()
        {
            _obstacleScale = Mathf.FloorToInt(transform.localScale.y);
        }
        
        public void DropBalls()
        {
            StackManager.Instance.Drop(_obstacleScale);
        }
    }
}
