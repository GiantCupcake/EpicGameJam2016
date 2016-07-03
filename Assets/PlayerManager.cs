using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
    public bool isActive;
    public string playerColor;
    public int credits;
    public int researchCredits;
    public builderScript builder;
    public List<GameObject> unitList;

    //  public GameObjectResearch Research;


    // Use this for initialization
    void Start () {
        researchCredits = 0;
        credits = 10;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void startTurn()
    {
        isActive = true;
        credits += 10 + researchCredits;
        unitList = builder.listGrunt;
        
    }
    void endTurn()
    {
        //TO DO : check all owned units who are detonating and detonates those who need and decrement one from ticking
        isActive = false;
    }
}
