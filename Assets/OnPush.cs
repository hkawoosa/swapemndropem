using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPush : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Movement m = other.GetComponent<Movement>();
        if (m != null)
        {
            m.Push(GetComponent<PushInfo>().getDirection(), GetComponent<PushInfo>().getForce());
        }
    }
}
