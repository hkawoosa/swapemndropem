﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPush : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Movement m = other.GetComponent<Movement>();
        if (m != null && other.tag != this.GetComponent<PushInfo>().tag)
        {
            Debug.Log(other);
            m.Push(GetComponent<PushInfo>().getDirection(), GetComponent<PushInfo>().getForce());
        }
    }
}
