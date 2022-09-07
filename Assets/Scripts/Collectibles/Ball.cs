using UnityEngine;

namespace StackRider.Collectibles
{
    public class Ball : MonoBehaviour, ICollectible
    {
        private BoxCollider _collider;
        private bool _isStacked;
        private void Start()
        {
            _collider = GetComponent<BoxCollider>();
        }
    

        public void OnCollect()
        {
            StackManager.Instance.Pickup(transform);
            _collider.isTrigger = true;
        }
    } 
}

