using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

	public GameObject player;
	public float hookTime;
	GameObject hookedPlayer;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Contains( "Player"))
		{
			StopCoroutine(player.GetComponent<PlayerController>().throwHook());
			StartCoroutine(other.GetComponent<PlayerController>().setStunned(hookTime));
			StartCoroutine(player.GetComponent<PlayerController>().pullHook());
			hookedPlayer = other.gameObject;
		}
		else //if (other.tag == "Wall" || other.tag == "ground")
		{
			StopCoroutine(player.GetComponent<PlayerController>().throwHook());
			StartCoroutine(player.GetComponent<PlayerController>().setStunned(hookTime / 2f));
			StartCoroutine(player.GetComponent<PlayerController>().pullHook());
		}
	}
}
