using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackRider.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float blendSpeed = 5f;
        
        private StackManager _stackManager;
        private GameManager _gameManager;

        private int _animIDMovementBlend;
        private float _movementBlend;
        private float _targetBlend;

        private int _animIDFail;
        private bool _fail;
        
        private int _animIDSuccess;
        private bool _success;


        public void Start()
        {
            _stackManager = StackManager.Instance;
            _gameManager = GameManager.Instance;
            InıtAnimIDs();
        }

        private void InıtAnimIDs()
        {
            _animIDMovementBlend = Animator.StringToHash("MoveBlend");
            _animIDFail = Animator.StringToHash("fail");
            _animIDSuccess = Animator.StringToHash("success");
        }
        
        public void Update()
        {
            _fail = (_gameManager.state == GameState.Failed);
            _success = (_gameManager.state == GameState.Success);
            CalculateBlending();
            Animate();
        }

        private void Animate()
        {
            animator.SetFloat(_animIDMovementBlend, _movementBlend);
            animator.SetBool(_animIDFail, _fail);
            animator.SetBool(_animIDSuccess, _success);
        }

        private void CalculateBlending()
        {
            _targetBlend = (_stackManager.NumberOfBalls % 2 == 0) ? 1f : -1f;
            _movementBlend = Mathf.Lerp(_movementBlend,_targetBlend , Time.deltaTime * blendSpeed);
        }
    }
    
}





