using UnityEngine;
using System.Collections;

public class Chateau : MonoBehaviour {

    const int MAX_HEALTH = 100;
    public int HP;

    public GameObject chato;

	// Use this for initialization
	void Start () {
        HP = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeDmg(int dmg)
    {
        //Baisse les HP
        HP -= dmg;

        if(HP <= 0)
        {
            //Call fin du jeu
        }
    }

    

}
