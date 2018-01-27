using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrigin : MonoBehaviour {

    GameObject player;

    public void SetPlayer(GameObject other)
    {
        player = other;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
