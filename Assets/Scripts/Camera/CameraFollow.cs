using System;
using System.Collections;
using UnityEngine;

namespace StackRider.CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Camera Follow")]
        [SerializeField] private Transform target;
        private float _offsetZ;
    
    
        [Header("Field Of View")]
        [SerializeField] private float minFOV;
        [SerializeField] private float maxFOV;
        [SerializeField] private float fovChangeSharpness;
        
        private float _currentFOV;
        private float _fovChangeRate;
        
        private Camera _camera;
        private StackManager _stackManager;
        private void Start()
        {
            _camera = GetComponent<Camera>();
            _offsetZ = transform.position.z - target.position.z;
            _currentFOV = _camera.fieldOfView;
            _stackManager = StackManager.Instance;
            _fovChangeRate = (maxFOV - minFOV) / _stackManager.maxStackAmount;
        }
    
        private void LateUpdate()
        {
            FollowTarget();
        }

        private void Update()
        {
            AdjustFOV();
        }

        private void AdjustFOV()
        {
            float targetFOV = minFOV + _fovChangeRate * _stackManager.NumberOfBalls;
            _currentFOV = Mathf.Lerp(_currentFOV, targetFOV, Time.deltaTime * fovChangeSharpness);
            _camera.fieldOfView = Mathf.Clamp(_currentFOV, minFOV, maxFOV);
            
        }

        private void FollowTarget()
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + _offsetZ);
        }
    }
}

