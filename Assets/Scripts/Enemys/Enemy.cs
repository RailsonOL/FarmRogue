using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int expValue = 1;

    //Logic
    public float triggerLenght = 1.0f;
    public float chaseLenght = 5.0f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startPosition;

    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        //check if player is in range
        if(Vector3.Distance(playerTransform.position, startPosition) < chaseLenght)
        {
            if(Vector3.Distance(playerTransform.position, startPosition) < triggerLenght) chasing = true;

            if(chasing)
            {
                if(!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }else{
                UpdateMotor(startPosition - transform.position);
            }
        }else{
            UpdateMotor(startPosition - transform.position);

            chasing = false;
        }

        //check for overlaps
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
            {
                if(hits[i].tag == "Player")
                {
                    collidingWithPlayer = true;
                }
            }

            //clean array
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience += expValue;
        GameManager.instance.ShowText("+" + expValue + " exp", 25, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
