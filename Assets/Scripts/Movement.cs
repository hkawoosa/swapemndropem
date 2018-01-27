using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //rigidbody for character physics
    Rigidbody rb;

    CapsuleCollider cc;

    //character's final run speed
    public float maxSpeed = 5;

    //speed which with character gets up to top speed
    public float acceleration = 5;

    //vertical speed character will jump with
    public float jumpPower = 5;

    public float gravity = 5;

    Vector3 velocity;
    Vector3 direction;

    bool jump;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        cc = this.GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {

        Vector3 xVelocity = velocity;
        xVelocity.y = 0;
        Vector3 groundDirection = direction * maxSpeed - xVelocity;

        float stepSize = Mathf.Min(acceleration * Time.deltaTime, groundDirection.magnitude);
        velocity += groundDirection * stepSize;

        RaycastHit hit;

        if (!Physics.SphereCast(this.transform.position, 1f, Vector3.down, out hit, cc.bounds.max.x))
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        if (jump)
        {
            velocity.y = jumpPower;
            jump = false;
        }

        rb.velocity = velocity;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Jump()
    {
        jump = true;
    }
}
