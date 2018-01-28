using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class ModeSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("P1_Jump"))
        {
            SceneManager.LoadScene("Map Select 1");
        }
        if (Input.GetButtonDown("P1_Push"))
        {
            SceneManager.LoadScene("Map Select 2");
        }
    }
}
