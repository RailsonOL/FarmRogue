using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Damage
    public int damage = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 1;
    private SpriteRenderer spriteRenderer;

    // Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time + lastSwing > cooldown)
        {
            lastSwing = Time.time;
            Swing();
        }
    }

    void OnCollide2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            
            //collision.gameObject.GetComponent<EnemyController>().Damage(damage);
            Vector2 pushDirection = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }

    void Swing()
    {
        Debug.Log("Swing");
        // Loop through all colliders
        // foreach(Collider2D collider in hitColliders)
        // {
        //     // Check if collider is an enemy
        //     if(collider.tag == "Enemy")
        //     {
        //         // Get enemy health
        //         Health health = collider.GetComponent<Health>();

        //         // Check if enemy has health
        //         if(health != null)
        //         {
        //             // Deal damage
        //             health.TakeDamage(damage);
        //         }

        //         // Get enemy rigidbody
        //         Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();

        //         // Check if enemy has rigidbody
        //         if(rigidbody != null)
        //         {
        //             // Push enemy
        //             rigidbody.AddForce(transform.right * pushForce, ForceMode2D.Impulse);
        //         }
        //     }
        // }
    }
}
