using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrigin : MonoBehaviour {

    GameObject player;

    public void SetPlayer(GameObject other)
    {
        player = other;
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
