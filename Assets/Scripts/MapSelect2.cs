using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MapSelect2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("P1_Jump"))
        {
            SceneManager.LoadScene("Not FD Two Player");
        }
        if (Input.GetButtonDown("P1_Push"))
        {
            SceneManager.LoadScene("Map 4 Two Player");
        }
        if (Input.GetButtonDown("P1_Swap"))
        {
            SceneManager.LoadScene("Not Battlefield 2 Player");
        }

    }
}
