using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainInfo : MonoBehaviour {

    Vector3 startPosition;
    float timeToDestination;
    Vector3 endPosition;
    bool reached = false;
    GameObject hooked;

    void FixedUpdate()
    {
        if (!reached)
        {
            if (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * timeToDestination);
            }
            else
            {
                reached = true;
            }
            
        }
        else
        {
            if (transform.position != startPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * timeToDestination);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        hooked = other.gameObject;
        Movement m = other.GetComponent<Movement>();
        if (m != null && other.tag != tag)
        {
            reached = true;
            m.getHooked(startPosition, timeToDestination);
        }
    }


    public void setStart(Vector3 start)
    {
        startPosition = start;
    }
    public Vector3 getStart()
    {
        return startPosition;
    }

    public void setTime(float time)
    {
        timeToDestination = time;
    }
    public float getTime()
    {
        return timeToDestination;
    }
    public void setEnd(Vector3 end)
    {
        endPosition = end;
    }
    public Vector3 getLength()
    {
        return endPosition;
    }
}
