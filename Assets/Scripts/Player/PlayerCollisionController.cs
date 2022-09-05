using System;
using UnityEngine;

namespace StackRider.Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        [SerializeField] private LayerMask finishLayer;

        private LevelManager _levelManager;

        private void Awake()
        {
            _levelManager = LevelManager.Instance;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent<ICollectible>(out ICollectible iCollectible))
            {
                iCollectible.OnCollect();
            }
            
            else if (collision.TryGetComponent<IObstacle>(out IObstacle iObstacle))
            {
                iObstacle.DropBalls();
            }
            
            else if ((finishLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                StartCoroutine(_levelManager.PassLevelAfterWait());
            }
        }
    }
}

