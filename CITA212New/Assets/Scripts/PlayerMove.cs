using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Vector2 posPlayer;
    [SerializeField] float playerSpeed = 10f;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TestMove();
    }

    public void OnMove(InputValue value)
    {
        posPlayer = value.Get<Vector2>() * playerSpeed;
        //posPlayer.y = value.gameobject.position.y;
        //posPlayer.x = value.gameobject.position.x;
        Debug.Log(posPlayer);
    }

    void TestMove ()
    {
        Vector2 playerSpeed = new Vector2(posPlayer.x, rb.linearVelocity.y);
        rb.linearVelocity = playerSpeed;
    }
}
