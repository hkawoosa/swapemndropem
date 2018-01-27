using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

	public GameObject player;
	public float hookTime;
	
	void OnTriggerEnter(Collider other)
	{
		
		
		StartCoroutine(player.GetComponent<PlayerController>().setStunned(hookTime));
		StartCoroutine(player.GetComponent<PlayerController>().pullHook();
	}
}
