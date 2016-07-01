using UnityEngine;
using System.Collections;

public class Neutral : MonoBehaviour {

    // Use this for initialization
    //Position sur la grille
    int posx;
    int posy;
    Vector3 position;
    int Id_player_owner;

    //Constructeur ??
    public Neutral(int _posx, int _posy)
    {

    }


	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

    public void setPos(Vector3 vec)
    {
        //On pourra le placer sur le modèle 3d avec ça.

    }

    public void unit_arrived()
    {
        //get l'unité qui est sur notre tuile
        //change Id_player_owner pour le joueur qui controle cette unité

    }

    //A rendre abstract
    public int collectBonus()
    {
        //Bonus selon la classe.
        int bonus = 0;
        return bonus;
    }



}
