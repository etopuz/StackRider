using System;
using UnityEngine;

namespace StackRider.Collectibles
{
    public class Gem : MonoBehaviour, ICollectible
    {

        [Header("Rotation")] 
        [SerializeField] private bool rotate; // do you want it to rotate?
        [SerializeField] private float rotationSpeed;

        private LevelManager _levelManager;

        private void Start()
        {
            _levelManager = LevelManager.Instance;
        }

        private void Update()
        {
            if (rotate)
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
            }
                
        }

        public void OnCollect()
        {
            _levelManager.AddGem();
            //AudioManager.Instance.PlayCollectAudio(transform.position);
            Destroy(gameObject);
        }
    }
}


