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
    private Rigidbody rb;

    public Generatorrr mapDerp;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        maxX = mapDerp.getWidth();          //et là ça passe
        maxY = mapDerp.getHeight();         //bisou
	}
	
	// Update is called once per frame
	void Update () {
	    if (hp <= 0)
            Destroy(this.gameObject);
	}


    void MoveLeft()
    {
        if ((posX > 0) && (moveLeft > 0))
        {
            moveTo(- 1, 0);
            posX--;
            moveLeft--;
        }
    }

    void MoveRight()
    {
        if ((posX < maxX) && (moveLeft > 0))
        {
            moveTo(1, 0);
            posX++;
            moveLeft--;
        }
    }

    void MoveUp()
    {
        if ((posY > 0) && (moveLeft > 0))
        {
            moveTo(0, - 1);
            posY--;
            moveLeft--;
        }
    }

    void MoveDown()
    {
        if ((posY < maxY) && (moveLeft > 0))
        {
            moveTo(0, 1);
            posY++;
            moveLeft--;
        }
    }

    void moveTo(int x, int y)
    {
        Vector3 movement = new Vector3(x, 0.0f, y);
        rb.AddForce(movement * 1);
    }
}
