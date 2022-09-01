using UnityEngine;

namespace StackRider.Player
{
    public class PlayerCollectController : MonoBehaviour
    {
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
        }
    }
}

