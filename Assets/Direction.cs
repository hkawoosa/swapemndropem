using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    int direction = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis(tag + "Horizontal") > 0)
        {
            direction = 1;
        }
        else if (Input.GetAxis(tag + "Horizontal") < 0)
        {
            direction = -1;
        }
        Debug.Log(direction);
	}

    public int GetDirection()
    {
        return direction;
    }
}
