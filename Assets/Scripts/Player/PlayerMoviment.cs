using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeedMultiplier;
    public bool isRuning;
    public bool isMoving;

    private float initalSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    public static PlayerMoviment instance;
    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        initalSpeed = moveSpeed;
    }
    void Update()
    {
        Run();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        isMoving = movement.sqrMagnitude > 0;
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRuning = true;
            moveSpeed = initalSpeed * runSpeedMultiplier;
        }
        else
        {
            isRuning = false;
            moveSpeed = initalSpeed;
        }
    }
}
