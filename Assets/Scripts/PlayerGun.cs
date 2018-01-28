using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

    Direction dir;

    public GameObject bullet;

    public float bulletSpeed = 6f;

    public float BulletDelay = .5f;
    float currentDelay = 0;

    // Use this for initialization
    void Start () {
        dir = GetComponent<Direction>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((CompareTag("P1_") || CompareTag("P2_")) && Input.GetButtonDown(this.tag + "Swap") && currentDelay <= 0 && !GetComponent<PlayerDeath>().IsDead())
        {
            currentDelay = BulletDelay;
            GameObject b = Instantiate(bullet, transform.position + (Vector3.right * dir.GetDirection()), Quaternion.identity);
            b.tag = this.tag;
            b.GetComponent<BulletOrigin>().SetPlayer(this.gameObject);
            b.GetComponent<Rigidbody>().velocity = dir.GetDirection() * Vector3.right * bulletSpeed;
        }

        currentDelay -= Time.deltaTime;
    }
}
