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

        private int _animIDMovementBlend;
        private float _movementBlend;
        private float _targetBlend;

        private int _animIDFail;
        private bool _fail;
        
        private int _animIDSuccess;
        private bool _success;


        public void Start()
        {
            _animIDMovementBlend = Animator.StringToHash("MoveBlend");
            _stackManager = StackManager.Instance;
        }
        
        public void Update()
        {
            Animate();
        }

        private void Animate()
        {
            _targetBlend = (_stackManager.NumberOfBalls % 2 == 0) ? 1f : -1f;
            _movementBlend = Mathf.Lerp(_movementBlend,_targetBlend , Time.deltaTime * blendSpeed);
            animator.SetFloat(_animIDMovementBlend, _movementBlend);
            // animator.SetBool(_animIDFail, _fail);
            // animator.SetBool(_animIDSuccess, _success);
        }
    }
    
}





