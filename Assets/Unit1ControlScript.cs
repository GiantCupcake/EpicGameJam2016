using UnityEngine;
using System.Collections;

public class Unit1ControlScript : MonoBehaviour {

    public int posX;
    public int posY;
    public int hp;
    public int moveMax;
    public int moveLeft;
    public int dmg;
    public int intox;


    private int maxX;
    private int maxY;

	// Use this for initialization
	void Start () {
        object mapDerp = FindObjectOfType(typeof(GameObject));
        maxX = mapDerp.sizeX;
        maxY = mapDerp.sizeY;
	}
	
	// Update is called once per frame
	void Update () {
	    if (hp == 0)
            Destroy(this.gameObject);
	}

    void MoveLeft()
    {
        if ((posX > 0) && (moveLeft > 0))
        {
            posX--;
            moveLeft--;
        }
    }

    void MoveRight()
    {
        if ((posX < maxX) && (moveLeft > 0))
        {
            posX++;
            moveLeft--;
        }
    }

    void MoveUp()
    {
        if ((posY > 0) && (moveLeft > 0))
        {
            posY--;
            moveLeft--;
        }
    }

    void MoveDown()
    {
        if ((posY < maxY) && (moveLeft > 0))
        {
            posY++;
            moveLeft--;
        }
    }
}
