using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //rigidbody for character physics
    Rigidbody rb;

    //character's final run speed
    public float maxSpeed = 1;

    //speed which with character gets up to top speed
    public float acceleration = 5;

    //vertical speed character will jump with
    public float jumpPower = 5;

    Vector3 velocity;
    Vector3 direction;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        direction = direction * maxSpeed - velocity;

        velocity += direction;

        rb.velocity = velocity;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
}
