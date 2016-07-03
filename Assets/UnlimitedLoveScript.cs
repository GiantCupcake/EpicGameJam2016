using UnityEngine;
using System.Collections;
using System;

public class UnlimitedLoveScript : UnitControlScript {

	// Use this for initialization
	void Start () {
		dmg = 3;
		hp = 1;
		maxMove = 5;
		bombTick = 1;
		remainingMoves = maxMove;
		posX = (int)transform.position.x;
		posY = (int)transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}