using UnityEngine;
using System.Collections;
using System;

public class GruntScript : UnitControlScript{

    public override void dealDmg()
    {

    }

    public override void getWrecked()
    {
        Destroy(this.gameObject);
    }

    public override void moveTo(float x, float y)
    {
        pathFinder((int)x, (int)y);
    }

    // Use this for initialization
    void Start()
    {
        dmg = 1;
        hp = 1;
        maxMove = 3;
        bombTick = 3;
        remainingMoves = maxMove;
        isDetonating = false;
        posX = (int)transform.position.x;
        posY = (int)transform.position.z;
    }

    // Update is called once per frame
    void Update () {
	
	}


    // A FAIRE : VERIFIER QUE LA CASE SOIT LIBRE UNE FOIS QUE NOTRE MAP ARRETE D'ETRE AUTISTE SVP MERCI
    void pathFinder(int destX, int destY)
    {
        while (posX > destX)
        {
            if (!MoveLeft())
                break;
        }
        while (posX < destX)
        {
            if (!MoveRight())
                break;
        }
        while (posY < destY)
        {
            if (!MoveDown())
                break;
        }
        while (posY > destY)
        {
            if (!MoveUp())
                break;
        }
    }
}
