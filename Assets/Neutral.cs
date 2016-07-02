using UnityEngine;
using System.Collections;

public class Neutral : MonoBehaviour {

    //Position sur la grille
    public int posx;
    public int posy;
    //Position unity
    public Vector3 position;
    //Qui ? Neutre 0, player 1,2,...
    public int Id_player_owner;


	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

    public void setPos(Vector3 vec)
    {
        //On pourra le placer sur le modèle 3d avec ça.
        position = vec;
    }

    public void unit_arrived(int Id_player)
    {
        //get l'unité qui est sur notre tuile
        //change Id_player_owner pour le joueur qui controle cette unité
        Id_player_owner = Id_player;
    }

    //A rendre abstract
    public int collectBonus()
    {
        //Bonus selon la classe.
        int bonus = 0;
        return bonus;
    }
}
