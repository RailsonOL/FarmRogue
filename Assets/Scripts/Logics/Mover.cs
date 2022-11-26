using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Warrior
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.00f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        //reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        //swap sprite direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Add push vector
        moveDelta += pushDirection;

        //Reduce push force every frame
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            //move y
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            //move x
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
