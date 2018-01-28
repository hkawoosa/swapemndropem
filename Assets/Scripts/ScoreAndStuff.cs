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

    }
}
