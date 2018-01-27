using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    public GameObject bullet;

    public float bulletSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(this.tag + "Swap"))
        {
            Debug.Log("shoot");
            GameObject b = Instantiate(bullet, transform.position + Vector3.right, Quaternion.identity);
            b.tag = this.tag;
            b.GetComponent<BulletOrigin>().SetPlayer(this.gameObject);
            b.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed;
        }
	}
}
