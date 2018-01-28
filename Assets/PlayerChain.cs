using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChain : MonoBehaviour {
    public GameObject chain;

    public float chainPushDelay = 4;
    float currentDelay = 0;

    float chainLength = 7f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(this.tag + "Pull") && currentDelay <= 0)
        {
            currentDelay = chainPushDelay;
            GetComponent<Movement>().setStunTime(chainPushDelay);
            GameObject b;
            int dir = this.GetComponent<Direction>().GetDirection();
            if (dir == -1)
            {
                Vector3 endPoint = transform.position;
                endPoint.x -= chainLength;
                b = Instantiate(chain, transform.position + (Vector3.right * dir), Quaternion.identity);
                b.GetComponent<ChainInfo>().setEnd(endPoint);
            }
            else
            {
                Vector3 endPoint = transform.position;
                endPoint.x += chainLength;
                b = Instantiate(chain, transform.position + (Vector3.right * dir), Quaternion.identity);
                b.GetComponent<ChainInfo>().setEnd(endPoint);
            }
            
            b.GetComponent<ChainInfo>().setStart(transform.position + (Vector3.right * dir));
            b.GetComponent<ChainInfo>().setTime(chainPushDelay/2);
            b.tag = tag;
        }
        currentDelay -= Time.deltaTime;
    }
}
