using UnityEngine;
using System.Collections;
using System;

public class GruntScript : UnitControlScript{

    ParticleSystem expl;
    GameObject expl_cont;
    AudioSource expl_sound;
    public override void Assplosion()
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
   //     TriggerExplosionFX();
        getWrecked();
    }

    void TriggerExplosionFX()
    {
        this.expl_sound.Play();
        this.expl.Emit(50);
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
        expl_cont = GameObject.Find("explosion_emt");
        expl = expl_cont.GetComponent<ParticleSystem>();
        expl_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TriggerExplosionFX();
        }
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
