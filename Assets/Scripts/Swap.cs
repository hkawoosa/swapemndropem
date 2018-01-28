using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour {

    public GameObject SwapMode;

    public float swapStun = .5f;

    public GameObject p1;
    public GameObject p2;

	// Use this for initialization
	void Start () {
        p1 = GameObject.Find("P1_");
        p2 = GameObject.Find("P2_");
	}

    public void SwapControl(GameObject other)
    {
        if(SwapMode.GetComponent<ScoreAndStuff>().style == ScoreAndStuff.Mode.victim)
        {
            if (CompareTag("Victim"))
            {
                this.tag = other.tag;
                Sprite temp = this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = temp;
                other.tag = "GoneFishing";
            }
           /** else if (CompareTag("P1_"))
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
            }*/
        }
        else
        {
            string temp = this.tag;
            this.tag = other.tag;
            Sprite tempSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = tempSprite;
            other.GetComponent<Movement>().setStunTime(swapStun);
            other.tag = temp;
        }
       
    }
}
