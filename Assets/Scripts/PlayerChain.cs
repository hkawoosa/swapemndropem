﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChain : MonoBehaviour {
    public GameObject chain;

    public float chainPushDelay = 4;
    float currentDelay = 0;
    public float timeToDestination = 15f;

	public AudioClip hookshotgrabbingon;
	public AudioClip hookshotgoingout;
	public AudioClip hookshotdrawingbackin;

	private AudioSource source3;
	private AudioSource source4;
	private AudioSource source5;

	public float vol = .3f;

    public float chainLength = 7f;

    // Update is called once per frame
    void Update()
    {
        if (((CompareTag("P1_") || CompareTag("P2_") || CompareTag("P3_") || CompareTag("P4_"))) && Input.GetButtonDown(this.tag + "Pull") && currentDelay <= 0 && !GetComponent<PlayerDeath>().IsDead())
        {
            currentDelay = chainPushDelay;
            GetComponent<Movement>().setStunTime(50);
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
                b = Instantiate(chain, transform.position + (Vector3.right * dir), Quaternion.Euler(0,0,180));
                b.GetComponent<ChainInfo>().setEnd(endPoint);
				source4 = GetComponent<AudioSource>();
				source4.PlayOneShot(hookshotgoingout,vol);
            }

            b.GetComponent<ChainInfo>().setParent(this.gameObject);
            b.GetComponent<ChainInfo>().setStart(transform.position + (Vector3.right * dir));
            b.GetComponent<ChainInfo>().setTime(timeToDestination);
            b.tag = tag;
        }
        currentDelay -= Time.deltaTime;
    }
}
