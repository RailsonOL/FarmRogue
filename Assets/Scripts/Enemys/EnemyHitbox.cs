using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage

    public int damagePoint = 1;
    public float pushForce = 2;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            Debug.Log("Hit player");

            Damage dmg = new Damage()
            {
                origin = transform.position,
                damageAmount = damagePoint,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
