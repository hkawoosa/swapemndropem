using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    BoxCollider bc;

    public Vector3 leftSide;
    public Vector3 rightSide;
    public float timeToTransverse = 1;
    Vector3 destination;
    
	
    // Use this for initialization
	void Awake () {
        bc = GetComponent<BoxCollider>();
        destination = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * timeToTransverse);
        }
        else
        {
            if (transform.position == leftSide && destination == leftSide)
            {
                destination = rightSide;
            }
            else if (transform.position == rightSide && destination == rightSide)
            {
                destination = leftSide;
            }
        }
    }
    
}
