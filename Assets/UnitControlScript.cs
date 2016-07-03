﻿using UnityEngine;
using System.Collections;

public abstract class UnitControlScript : MonoBehaviour {
    public GameObject explosionFX;
    public GameObject map;
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
    public bool exploded;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TriggerExplosionFX();
        }
        
    }

    public void Assplosion()
    {
        int i = 1;
        int x;
        int y;

        exploded = true;
        while (dmg > 0)
        {
            y = posY - i;
            while (y - 1 < posY + i)
            {
                x = posX - i;
                while (x - 1 < posX + i)
                {
                    print("x : " + x + " ---- y : " + y);
                    InflictsDmg(x, y);
                    x++;
                }
                y++;
            }
            i++;
            dmg--;
        }
        getWrecked();
    }

    public void moveTo(float x, float y)
    {
        FindObjectOfType<Manager>().ShutdownTiles();
        pathFinder((int)x, (int)y);
        FindObjectOfType<Manager>().HilightTiles(posX, posY, remainingMoves + 1);
    }

    public void getWrecked()
    {
        TriggerExplosionFX();
        if (!exploded)
            this.Assplosion();
        PlayerManager[] players = FindObjectsOfType<PlayerManager>();
        players[0].ownedUnits.Remove(GetComponent<UnitControlScript>());
        players[0].ownedUnits.Remove(GetComponent<UnitControlScript>());
        Destroy(this.gameObject);
    }


    void TriggerExplosionFX()
    {
        Instantiate(explosionFX, this.transform.position, Quaternion.identity);
    }

    public void InflictsDmg(int x, int y)
    {
        UnitControlScript victim;

        if ((victim = Manager.MapContains(x, y)) != null)
        {
            victim.hp -= 1 * intox;
            if (victim.hp <= 0)
                victim.Assplosion();
        }
    }

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
