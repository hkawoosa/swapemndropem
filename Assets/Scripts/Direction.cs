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
		if (((CompareTag("P1_") || CompareTag("P2_") || CompareTag("P3_") || CompareTag("P4_"))) && Input.GetAxis(tag + "Horizontal") > 0)
        {
            direction = 1;
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            this.transform.localScale = newScale;
        }
        else if (((CompareTag("P1_") || CompareTag("P2_") || CompareTag("P3_") || CompareTag("P4_"))) && Input.GetAxis(tag + "Horizontal") < 0)
        {
            direction = -1;
            Vector3 newScale = transform.localScale;
            newScale.x = -Mathf.Abs(newScale.x);
            this.transform.localScale = newScale;
        }
	}

    public int GetDirection()
    {
        return direction;
    }
}
