using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Swap s = other.GetComponent<Swap>();
        if(other.gameObject.layer == LayerMask.NameToLayer("Victim") || other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            s.SwapControl(GetComponent<BulletOrigin>().GetPlayer());
        }

        GetComponent<BulletOrigin>().GetPlayer().transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        Destroy(this.gameObject);
    }
}
