using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;

	// Use this for initialization
	void Start () {
        p1 = GameObject.Find("P1_");
        p2 = GameObject.Find("P2_");
	}

    public void SwapControl(GameObject other)
    {
        if (CompareTag("Victim"))
        {
            this.tag = other.tag;
            other.tag = "GoneFishing";
        }
        else if (CompareTag("P1_"))
        {
            this.tag = other.tag;
            other.tag = "GoneFishing";
            p1.tag = "P1_";

        }
        else if (CompareTag("P2_"))
        {
            this.tag = other.tag;
            other.tag = "GoneFishing";
            p2.tag = "P2_";
        }
    }
}
