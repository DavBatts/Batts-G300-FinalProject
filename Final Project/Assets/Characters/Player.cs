using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float runSpeed = 2.0f;
    public float walkSpeed = 1.0f;
    public override void Start()
    {
        base.Start();
        speed = runSpeed;
    }
    public override void Update()
    {
        base.Update();
        direction = Input.GetAxisRaw("Horizontal");
        HandleJumping();
    }

    protected override void HandleMovement()
    {
        base.HandleMovement();
        myAnimator.SetFloat("speed", Mathf.Abs(direction));
        TurnAround(direction);
    }

    protected override void HandleJumping()
    {
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("falling", false);
        }


        // if jump button is pushed
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
            stoppedJumping = false;
            //tell the animator to play jump animation
            myAnimator.SetTrigger("jump");
        }

        //if jump button is held
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {


            //Jump!!!
            Jump();
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("jump");
        }

        //If jump button is released
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            myAnimator.SetBool("falling", true);
            myAnimator.ResetTrigger("jump");
        }
    }
}
