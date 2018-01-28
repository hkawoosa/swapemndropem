using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndStuff : MonoBehaviour {

    public enum Mode { teams, victim };
    int Team1Score = 0;//Player 1 in victim, 1 and 3 in teams
    int Team2Score = 0;//Player 2 in victim, 2 and 4 in teams

    public Mode style;

    public GameObject[] pcc;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScore(GameObject deadPlayer)
    {
        if (deadPlayer.GetComponent<Movement>().getOriginalTag() == "Victim")
        {
            if (deadPlayer.tag == "P1_")
            {
                Team1Score++;
            }
            else if (deadPlayer.tag == "P2_")
            {
                Team2Score++;
            }
            else
            {
                Team1Score--;
                Team2Score--;
            }
        }
        else if (deadPlayer.GetComponent<Movement>().getOriginalTag() == "P1_" || deadPlayer.GetComponent<Movement>().getOriginalTag() == "P3_")
        {
            if(deadPlayer.tag == "P2_" || deadPlayer.tag == "P4_")
            {
                Team2Score++;
            }
            else
            {
                Team1Score--;
            }
        }
        else if (deadPlayer.GetComponent<Movement>().getOriginalTag() == "P2_" || deadPlayer.GetComponent<Movement>().getOriginalTag() == "P4_")
        {
            if (deadPlayer.tag == "P1_" || deadPlayer.tag == "P3_")
            {
                Team1Score++;
            }
            else
            {
                Team2Score--;
            }
        }

    }

    public void ManageRespawn()
    {
        for(int i = 0; i < pcc.Length; i++)
        {
            //current head = original head
            pcc[i].tag = pcc[i].GetComponent<Movement>().getOriginalTag();
        }
    }
}
