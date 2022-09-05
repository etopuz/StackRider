using System;
using System.Runtime.CompilerServices;
using StackRider.Inputs;
using Unity.VisualScripting;
using UnityEngine;

namespace StackRider.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Speed")]
        [SerializeField] private float horizontalMovementSpeed = 5f;
        [SerializeField] private float verticalMovementSpeed = 20f;

        [Header("Bound References")]
        [SerializeField] private Transform road;
        [SerializeField] private Transform sphere;

        private GameManager _gameManager;
        
        private float _lastFrameFingerPositionX;
        private float _moveFactorX;

        private float _movementBound;

        private void Start()
        {
            Input.multiTouchEnabled = false;
            _gameManager = GameManager.Instance;
            _movementBound = (road.localScale.x - sphere.localScale.x) / 2f;
        }
        
        private void Update()
        {
            if (_gameManager.state == GameState.Playing)
            {
                Move();
                ClampMovement();
            }
        }

        private void Move()
        {
            Vector3 moveVector = new Vector3(SwerveInput.Instance.MoveFactorX * horizontalMovementSpeed,0 ,verticalMovementSpeed) * Time.deltaTime;
            transform.Translate(moveVector);
        }
        
        private void ClampMovement()
        {
            float clampPosition = Mathf.Clamp(transform.position.x,-_movementBound,_movementBound);
            transform.position = new Vector3(clampPosition, transform.position.y, transform.position.z);
        }
    }
}

