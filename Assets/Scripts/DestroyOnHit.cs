using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Movement m = other.GetComponent<Movement>();
        if(m != null)
        {
            m.Swap(GetComponent<BulletOrigin>().GetPlayer());
        }
        Destroy(this.gameObject);
    }
}
