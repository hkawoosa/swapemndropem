using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndStuff : MonoBehaviour {

    public enum Mode { teams, victim };
    int Team1Score = 0;//Player 1 in victim, 1 and 3 in teams
    int Team2Score = 0;//Player 2 in victim, 2 and 4 in teams

    public Text score1;
    public Text score2;

    public Mode style;

    public GameObject[] pcc;

    int found = -1;
	// Use this for initialization
	void Start () {
        score1 = GameObject.Find("Team 1").GetComponent<Text>();
        score2 = GameObject.Find("Team 2").GetComponent<Text>();
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
        score1.text = "" + Team1Score;
        score2.text = "" + Team2Score;

    }

    public void ManageRespawn(GameObject player)
    {
        if(style == Mode.victim)
        {
            for (int i = 0; i < pcc.Length; i++)
            {
                if (pcc[i].GetComponent<Movement>().getOriginalTag() == player.tag)
                {
                    pcc[i].tag = player.tag;
                    pcc[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                }

            }
            player.tag = player.GetComponent<Movement>().getOriginalTag();
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = player.GetComponent<Movement>().getOriginalHead();
        }
        else
        {
            if(player.tag != player.GetComponent<Movement>().getOriginalTag())
            {
                for (int i = 0; i < pcc.Length; i++)
                {
                    if (pcc[i].GetComponent<Movement>().getOriginalTag() == player.tag)
                    {
                        found = i;

                    }
                }
                    if (player.GetComponent<Movement>().getOriginalTag() != pcc[found].tag)
                    {
                        for (int j = 0; j < pcc.Length; j++)
                        {
                            if (player.GetComponent<Movement>().getOriginalTag() == pcc[j].tag)
                            {
                                pcc[j].tag = pcc[found].tag;
                                pcc[j].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = pcc[found].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                            }
                        }
                        pcc[found].tag = player.tag;
                        pcc[found].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                    }
                player.tag = player.GetComponent<Movement>().getOriginalTag();
                player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = player.GetComponent<Movement>().getOriginalHead();
            } 
        }
    }
}
