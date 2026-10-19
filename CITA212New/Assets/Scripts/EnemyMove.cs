using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
