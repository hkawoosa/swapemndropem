using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject player;

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
                GameObject a = Instantiate(player, respawnPosition, Quaternion.identity);
                Destroy(this.gameObject);

            }
        }
        currentCounter -= Time.deltaTime;


	}
}
