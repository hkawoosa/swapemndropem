using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    Direction dir;

    public GameObject bullet;

    public float bulletSpeed = 3f;

	// Use this for initialization
	void Start () {
        dir = GetComponent<Direction>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!CompareTag("Victim") && Input.GetButtonDown(this.tag + "Swap"))
        {
            GameObject b = Instantiate(bullet, transform.position + (Vector3.right * dir.GetDirection()), Quaternion.identity);
            b.tag = this.tag;
            b.GetComponent<BulletOrigin>().SetPlayer(this.gameObject);
            b.GetComponent<Rigidbody>().velocity = dir.GetDirection() * Vector3.right * bulletSpeed;
        }
	}
}
