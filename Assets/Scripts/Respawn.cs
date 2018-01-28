using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject playerManaging;
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
                playerManaging.GetComponent<ScoreAndStuff>().ManageRespawn(this.gameObject);
                currentCounter = deathLength;
            }
            else
            {
                GetComponent<PlayerDeath>().undie();
                transform.rotation = Quaternion.identity;
                playerManaging.GetComponent<ScoreAndStuff>().ManageRespawn(this.gameObject);
                transform.position = respawnPosition;
                passOne = true;
            }
        }
        currentCounter -= Time.deltaTime;


	}
}
