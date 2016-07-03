using UnityEngine;
using System.Collections;
using System;

public class KatyushaScript : UnitControlScript {

	// Use this for initialization
	void Start () {
		dmg = 0;
		hp = 6;
		maxMove = 4;
		bombTick = 2;
		remainingMoves = maxMove;
		posX = (int)transform.position.x;
		posY = (int)transform.position.z;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
