using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    //public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    //Imnutability 
    public float imuneTime = 1.0f;
    private float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //All Warrior can recive damage / die
    
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > imuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized;
            pushDirection *= dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 20, 1.0f);

            if(hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
