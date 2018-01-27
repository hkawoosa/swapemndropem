using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //rigidbody for character physics
    Rigidbody rb;

    CapsuleCollider cc;

    PlayerDeath pd;

    //character's final run speed
    public float maxSpeed = 5;

    //speed which with character gets up to top speed
    public float acceleration = 5;

    //vertical speed character will jump with
    public float groundedJumpPower = 10;
    public float doubleJumpPower = 8;

    public float gravity = 5;

    Vector3 velocity;
    Vector3 direction;

    int jumpsRemaining = 2;
    public float jumpBuffer = 0f;

    bool stunned = false, usingHook = false;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        cc = this.GetComponent<CapsuleCollider>();
        pd = this.GetComponent<PlayerDeath>();
    }

    void FixedUpdate()
    {
        if (!pd.IsDead())
        {
            Vector3 newX = rb.velocity;
            newX.x = Input.GetAxis(this.tag + "Horizontal") * maxSpeed;
            rb.velocity = newX;
        }

        RaycastHit hit;

        Debug.Log(jumpsRemaining);

        Vector3 newY = rb.velocity;
        if (Physics.SphereCast(this.transform.position, 1f, Vector3.down, out hit, cc.bounds.extents.x))
        {
            if(jumpBuffer <= 0)
            {
                jumpsRemaining = 2;
            }
            else
            {
                jumpBuffer -= Time.deltaTime;
            }
            
        }
        else
        {
            if(jumpsRemaining == 2)
            {
                jumpsRemaining = 1;
            }
            newY.y -= gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown(this.tag + "Jump"))
        {
            if(jumpsRemaining == 2)
            {
                newY.y = groundedJumpPower;
                jumpsRemaining--;
                jumpBuffer = .2f;
            }
            else if(jumpsRemaining == 1)
            {
                newY.y = doubleJumpPower;
                jumpsRemaining--;
            }
            
        }
        rb.velocity = newY;


    }

    public void SetDirection(Vector3 direction)
    {
        
    }

    public void Jump()
    {
        
    }

    public void SetStunned(bool state)
    {
        stunned = state;
    }
    public void SetUsingHook(bool state)
    {
        usingHook = state;
    }
}
