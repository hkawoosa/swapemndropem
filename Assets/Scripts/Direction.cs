using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    int direction = 1;

    SpriteRenderer body;
    SpriteRenderer head;

	// Use this for initialization
	void Start () {
        body = GetComponent<SpriteRenderer>();
        head = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!CompareTag("Victim") && Input.GetAxis(tag + "Horizontal") > 0)
        {
            direction = 1;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!CompareTag("Victim") && Input.GetAxis(tag + "Horizontal") < 0)
        {
            direction = -1;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
	}

    public int GetDirection()
    {
        return direction;
    }
}
