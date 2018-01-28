using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    public float destroyTime;

    GameObject player = null;

	// Use this for initialization
	void Start () {
        BulletOrigin b = GetComponent<BulletOrigin>();
        if(b != null)
        {
            player = b.GetPlayer();
        }
        StartCoroutine(head());    
	}

    IEnumerator head()
    {
        yield return new WaitForSeconds(destroyTime); 
        if (player != null)
        {
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
        Destroy(this.gameObject);
    }
}
