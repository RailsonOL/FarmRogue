using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : Collidable
{
    // Damage
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 1;
    private SpriteRenderer spriteRenderer;

    // Swing
    private Animator anim;
    public float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();

        spriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //Debug.Log(Time.time - lastSwing > cooldown ? "Ready" : "Not Ready");
        if (Input.GetButtonDown("Fire1") && Time.time - lastSwing > cooldown)
        {
            lastSwing = Time.time;
            Swing();
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);

        if (coll.tag == "Enemy")
        {
            if(coll.name == "Player") return;

            //Debug.Log("Hit enemy: " + damagePoint);

            Damage dmg = new Damage()
            {
                origin = transform.position,
                damageAmount = damagePoint,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    void Swing()
    {
        anim.SetTrigger("Swing");
    }
}
