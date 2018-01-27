using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour {
    public GameObject push;

    public float force = 12;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(this.tag + "Push"))
        {
            int dir = this.GetComponent<Direction>().GetDirection();
            GameObject b = Instantiate(push, transform.position + (Vector3.right * dir), Quaternion.identity);
            b.GetComponent<PushInfo>().setDirection(dir);
            b.GetComponent<PushInfo>().setForce(force);
            b.GetComponent<Rigidbody>().velocity = dir * Vector3.right * force;
        }
    }
}
