using UnityEngine;
using System.Collections.Generic;

public class PlayerManagerRed : PlayerManager {

    // Use this for initialization
    void Start () {
        researchCredits = 0;
        credits = 10;
        playerColor = "red";
        startTurn();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
