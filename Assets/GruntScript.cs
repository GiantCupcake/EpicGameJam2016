using UnityEngine;
using System.Collections;
using System;

public class GruntScript : UnitControlScript { 

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
        expl = GetComponent<ParticleSystem>();
        if (expl == null)
        {
            Debug.Log("particle null");
        }
        expl_sound = GetComponent<AudioSource>();
        if (expl_sound == null)
        {
            Debug.Log("particle null");
        }
    }

    // Update is called once per frame
<<<<<<< HEAD
    void Update()
=======
    void Update () {

	}


    // A FAIRE : VERIFIER QUE LA CASE SOIT LIBRE UNE FOIS QUE NOTRE MAP ARRETE D'ETRE AUTISTE SVP MERCI
    void pathFinder(int destX, int destY)
>>>>>>> 5007c16f5cd693aa11cf3f786154f8618a8a4a6a
    {

    }
}
