using UnityEngine;
using System.Collections;

public abstract class UnitControlScript : MonoBehaviour {

    public builderScript builder;
    public int maxMove;
    public int remainingMoves;
    public int hp;
    public int posX;
    public int posY;
    public int dmg;
    public int bombTick;
    public int intox;
    public string owner;
    private int maxX;
    private int maxY;

	// Use this for initialization
	void Start () {
        intox = 1;
        maxX = builder.MapWidth;
        maxY = builder.MapHeight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void moveTo(float x, float y);
    public abstract void getWrecked();
    public abstract void dealDmg();

    public bool MoveLeft()
    {
        if ((posX > 0) && (remainingMoves > 0))
        {
            moveTo(-1, 0);
            posX--;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }

    public bool MoveRight()
    {
        if ((posX < maxX - 1) && (remainingMoves > 0))
        {
            moveTo(1, 0);
            posX++;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }

    public bool MoveUp()
    {
        if ((posY > 0) && (remainingMoves > 0))
        {
            moveTo(0, -1);
            posY--;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }

    public bool MoveDown()
    {
        if ((posY < maxY - 1) && (remainingMoves > 0))
        {
            moveTo(0, 1);
            posY++;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }
}
