using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    BoxCollider bc;

    public Vector3 leftSide;
    public Vector3 rightSide;
    public float timeToTransverse = 8;
    Vector3 destination;
	
    // Use this for initialization
	void Awake () {
        bc = GetComponent<BoxCollider>();
        destination = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log(destination);
        if (destination == rightSide)
        {
            destination = leftSide;
        }
        else if (destination == leftSide)
        {
            destination = rightSide;
        }
    }

    IEnumerator move()
    {
        float rate = 1 / timeToTransverse;
        float index = 0.0f;
        Vector3 startPosition = this.transform.position;

        

        while (index < 1.0)
        {
            transform.position = Vector3.Lerp(startPosition, destination, index);
            index += rate * Time.deltaTime;
            yield return new WaitForSeconds(timeToTransverse);

        }
        transform.position = destination;

        yield return null;
    }
    
}
