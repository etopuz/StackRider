using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace StackRider.Inputs
{
    public class SwerveInput : Singleton<SwerveInput>
    {
        public float MoveFactorX => _moveFactorX;

        public bool isEnabled = true;
        
        private float _lastFrameFingerPositionX;
        private float _moveFactorX;

        private GameManager _gameManager;

        protected override void Awake()
        {
            _gameManager = GameManager.Instance;
        }
        private void Update()
        {
            isEnabled = (_gameManager.state == GameState.Playing);
            
            if (isEnabled)
            {
                Swerve();
            }
        }


        private void Swerve()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
        }
    }
}
