﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour {
    public GameObject Push;

    public float distanceFromPlayer = 1f;

    public float force = 12;

    public float forcePushDelay = 2;
    float currentDelay = 0;


    // Update is called once per frame
    void Update () {
        if (((CompareTag("P1_") || CompareTag("P2_") || CompareTag("P3_") || CompareTag("P4_"))) && Input.GetButtonDown(this.tag + "Push") && currentDelay <= 0 && !GetComponent<PlayerDeath>().IsDead())
        {
            currentDelay = forcePushDelay;
            GameObject b;
            int dir = this.GetComponent<Direction>().GetDirection();
            if (dir == -1)
            {
                b = Instantiate(Push, transform.position + (Vector3.right * dir), Quaternion.identity);
            }
            else
            {
                b = Instantiate(Push, transform.position + (Vector3.right * dir), Quaternion.identity);
            }
            b.GetComponent<PushInfo>().setTag(this.tag);
            b.GetComponent<PushInfo>().setDirection(dir);
            b.GetComponent<PushInfo>().setForce(force);
            b.GetComponent<Rigidbody>().velocity = dir * Vector3.right * force;
        }
        currentDelay -= Time.deltaTime;
    }
}
