using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
    public bool isActive;
    public string playerColor;
    public int credits;
    public int researchCredits;
    public builderScript builder;
    public List<GameObject> unitList;
    public List<GameObject> ownedUnits = new List<GameObject>();

    //  public GameObjectResearch Research;


    // Use this for initialization
    void Start () {
        researchCredits = 0;
        credits = 10;
        playerColor = "red";
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void startTurn()
    {
        isActive = true;
        credits += 10 + researchCredits;
        unitList = builder.listGrunt;
        foreach (GameObject unit in unitList)
        {
            if (unit.GetComponent<UnitControlScript>().owner == playerColor)
                ownedUnits.Add(unit);
        }
    }

    void endTurn()
    {
        foreach (GameObject unit in ownedUnits)
        {
            if (unit.GetComponent<UnitControlScript>().bombTick <= 0)
                unit.GetComponent<UnitControlScript>().getWrecked();
            else if (unit.GetComponent<UnitControlScript>().isDetonating)
                unit.GetComponent<UnitControlScript>().bombTick--;
        }
        ownedUnits.Clear();
        isActive = false;
    }
}
