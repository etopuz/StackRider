using StackRider;
using UnityEngine;

namespace  StackRider.Collectible
{
    public class Chest : MonoBehaviour, ICollectible
    {
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private int numberOfBonusBall = 2;
        public void OnCollect()
        {
            for (int i = 0; i < numberOfBonusBall; i++)
            {
                Transform ball = Instantiate(ballPrefab).transform;
                StackManager.Instance.Pickup(ball);
            }
            Destroy(gameObject);
        }
    }
}

