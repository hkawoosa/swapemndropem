using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public float deathLength = 5;
    float currentCounter = 0;
    bool passOne = true;
    Vector3 respawnPosition;

    void Awake()
    {
        respawnPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        if (GetComponent<PlayerDeath>().IsDead() && currentCounter <= 0)
        {
            if (passOne)
            {
                passOne = false;
                currentCounter = deathLength;
            }
            else
            {
                GetComponent<PlayerDeath>().undie();
                transform.rotation = Quaternion.identity;
                if(tag != GetComponent<Movement>().getOriginalTag())
                {
                    string temp = tag;
                    tag = GetComponent<Movement>().getOriginalTag();
                }
                transform.position = respawnPosition;
            }
        }
        currentCounter -= Time.deltaTime;


	}
}
