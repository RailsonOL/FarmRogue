using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : Mover
{
    public float runSpeed = 6.5f;
    public bool isRunning;
    private float startSpeed;
    public bool isMoving;
    private Vector2 movement;

    public static PlayerMoviment instance;
    protected override void Start() {
        base.Start();
        instance = this;
        startSpeed = base.speedMultiplier;    
    }

    private void Update() {
        Run();
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        UpdateMotor(movement);

        isMoving = movement.sqrMagnitude > 0;
    }

    private void Run(){
        if(Input.GetKey(KeyCode.LeftShift)){
            base.speedMultiplier = runSpeed;
            isRunning = true;
        }else{
            base.speedMultiplier = startSpeed;
            isRunning = false;
        }
    }
}
