using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChateauScript : MonoBehaviour {

    int player = 0;
    const int MAX_HEALTH = 100;
    public int hp;
    public string owner;
    public GameObject panel; 
    public GameObject chato;

	// Use this for initialization
	void Start () {
        hp = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetPlayer() { return player; }
    void setPlayer(int _input) { player = _input; }

    public void takeDmg(int dmg)
    {

        //Baisse les HP
        hp -= dmg;

        if(hp <= 0)
        {
            
        }
    }

    public void createUnit()
    {
   //     Instantiate(GetComponent<Unit1ControlScript>().gameObject, transform.position, Quaternion.identity);
    }
}
