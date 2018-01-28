using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Swap s = other.GetComponent<Swap>();
        if(other.gameObject.layer == LayerMask.NameToLayer("Victim"))
        {
            s.SwapControl(GetComponent<BulletOrigin>().GetPlayer());
        }
        Destroy(this.gameObject);
    }
}
