using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<ICollectible>(out ICollectible iCollectible))
        {
            iCollectible.OnCollect();
        }
    }
}
