using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChateauScript : MonoBehaviour {

    int player = 0;
    const int MAX_HEALTH = 100;
    public int hp;
    public string owner;
    public GameObject panel;
    public Text[] victory;
    public GameObject chato;

	// Use this for initialization
	void Start () {
        hp = MAX_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
        takeDmg(0);
	}

    public int GetPlayer() { return player; }
    void setPlayer(int _input) { player = _input; }

    public void takeDmg(int dmg)
    {

        //Baisse les HP
        hp -= dmg;

        if(hp <= 0)
        {
            victory = FindObjectsOfType<Text>();
            string winner;
            if (owner == "red")
                winner = "green";
            else
                winner = "red";
            foreach(Text derp in victory) {
                if (derp.name == "Victory Text")
                {
                    derp.text = "Shame on you " + owner + "s ! You let the filthy " + winner + "s destroy your castle !";
                    derp.GetComponent<Text>().enabled = true;
                }
            }
        }
    }

    public void createUnit()
    {
   //     Instantiate(GetComponent<Unit1ControlScript>().gameObject, transform.position, Quaternion.identity);
    }
}
