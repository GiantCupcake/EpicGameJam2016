using UnityEngine;
using System.Collections;

public class ChateauScript : MonoBehaviour {

    int player = 0;
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

    public int GetPlayer() { return player; }
    void setPlayer(int _input) { player = _input; }

    public void takeDmg(int dmg)
    {
        //Baisse les HP
        HP -= dmg;

        if(HP <= 0)
        {
            //Call fin du jeu
        }
    }

    public void createUnit()
    {
   //     Instantiate(GetComponent<Unit1ControlScript>().gameObject, transform.position, Quaternion.identity);
    }
}
