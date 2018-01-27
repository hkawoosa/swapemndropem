using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour {

	public GameObject player;
	public float strength;
	// Use this for initialization
	
	public void OnTriggerEnter(Collider other)
	{
		Vector3 ang = other.transform.position - player.transform.position;
		other.GetComponent<Rigidbody>().AddForce(ang.normalized * strength, ForceMode.Force);
	}
}
