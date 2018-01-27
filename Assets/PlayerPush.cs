﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour {
    public GameObject push;

    public float distanceFromPlayer = 3f;

    public float force = 12;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!CompareTag("Victim") && Input.GetButtonDown(this.tag + "Push"))
        {
            GameObject b;
            int dir = this.GetComponent<Direction>().GetDirection();
            if(dir == -1)
            {
                b = Instantiate(push, transform.position + (Vector3.right * dir) * distanceFromPlayer, Quaternion.identity);
            }
            else
            {
                b = Instantiate(push, transform.position + (Vector3.right * dir) * distanceFromPlayer, Quaternion.identity);
            }
            b.GetComponent<PushInfo>().setTag(this.tag);
            b.GetComponent<PushInfo>().setDirection(dir);
            b.GetComponent<PushInfo>().setForce(force);
            b.GetComponent<Rigidbody>().velocity = dir * Vector3.right * force;
        }
    }
}
