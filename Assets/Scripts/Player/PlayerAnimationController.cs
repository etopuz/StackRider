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
        private int _animIDMovementBlend;
        private float _movementBlend;
        

        private int _animIDFail;
        private bool _fail;
        
        private int _animIDSuccess;
        private bool _success;


        public void Start()
        {
            _animIDMovementBlend = Animator.StringToHash("MoveBlend");
        }

        public void Update()
        {
            Animate();
        }

        private void Animate()
        {
            _movementBlend = Mathf.Lerp(_movementBlend, StackManager.Instance.moveForward, Time.deltaTime * blendSpeed);

            animator.SetFloat(_animIDMovementBlend, _movementBlend);
            // animator.SetBool(_animIDFail, _fail);
            // animator.SetBool(_animIDSuccess, _success);
        }
    }
    
}





