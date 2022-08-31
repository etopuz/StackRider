using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private bool _isPlaying;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        _isPlaying = GameManager.Instance.state == GameState.Playing;

        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        Vector3 moveVector = new Vector3(h,0,1) * (moveSpeed * Time.deltaTime);

        transform.Translate(moveVector);
    }
}
