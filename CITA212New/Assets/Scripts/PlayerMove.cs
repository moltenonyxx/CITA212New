using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector2 posPlayer;
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    CapsuleCollider2D playerCollider;
    BoxCollider2D feetCollider;
    Rigidbody2D rb;
    bool Alive = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    public void OnMove(InputValue value)
    {
        posPlayer = value.Get<Vector2>() * playerSpeed;
    }

    void Run ()
    {
        Vector2 playerSpeed = new Vector2(posPlayer.x, rb.linearVelocity.y);
        rb.linearVelocity = playerSpeed;
    }
    public void OnJump(InputValue value)
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Tilemap Layer")))
        {
            return; // in the air: ignore jump
        }
        if (!Alive)
        {
            return;
        }
        if (value.isPressed)
        { 
            rb.linearVelocity +=
            new Vector2(0f, jumpSpeed);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            Alive = false;
            Debug.Log("hit enemy");
        }
    }
}
