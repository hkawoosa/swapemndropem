using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainInfo : MonoBehaviour {

    Vector3 startPosition;
    float timeToDestination;
    Vector3 endPosition;
    bool reached = false;
    GameObject par;
    public float distancePerTime = .25f;

    void FixedUpdate()
    {
        if (!reached)
        {
            if (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, distancePerTime);
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
                transform.position = Vector3.MoveTowards(transform.position, startPosition, distancePerTime);
            }
            else
            {
                par.GetComponent<Movement>().setStunTime(0.0f);
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Movement m = other.GetComponent<Movement>();
        if (m != null && other.tag != tag)
        {
            reached = true;
            m.getHooked(startPosition, distancePerTime);
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
    public void setParent(GameObject pa)
    {
        par = pa;
    }
}
