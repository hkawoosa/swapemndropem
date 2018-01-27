using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Enemy")) {
            Vector3 direction = col.relativeVelocity.normalized;
            GetComponent<Rigidbody>().AddForce(direction);
        }
    }
}
