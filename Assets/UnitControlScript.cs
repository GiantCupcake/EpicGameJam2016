using UnityEngine;
using System.Collections;

public abstract class UnitControlScript : MonoBehaviour {

    public GameObject builder;
    public int maxMove;
    public int remainingMoves;
    public int hp;
    public int posX;
    public int posY;
    public int dmg;
    public int bombTick;
    public int intox = 1;
    public bool isDetonating;
    public string owner;
    public int maxX;
    public int maxY;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public abstract void moveTo(float x, float y);
    public abstract void getWrecked();
    public abstract void dealDmg();

    void bruleTripot(int x, int y)
    {
        transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y);
    }

    public bool MoveLeft()
    {
        if ((posX >= 0) && (remainingMoves > 0))
        {
            bruleTripot(-1, 0);
            posX--;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }

    public bool MoveRight()
    {
        if (remainingMoves > 0)
        {
            bruleTripot(1, 0);
            posX++;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }

    public bool MoveUp()
    {
        if ((posY >= 0) && (remainingMoves > 0))
        {
            bruleTripot(0, -1);
            posY--;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }

    public bool MoveDown()
    {
        if (remainingMoves > 0)
        {
            bruleTripot(0, 1);
            posY++;
            remainingMoves--;
            return true;
        }
        else
            return false;
    }
}
