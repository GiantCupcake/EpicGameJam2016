using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerManager : MonoBehaviour
{

    public bool isActive;
    public string playerColor;
    public int credits;
    public int researchCredits;
    public builderScript builder;
    public List<UnitControlScript> unitList;
    public List<UnitControlScript> ownedUnits = new List<UnitControlScript>();
    public Text uiPanel;
    public Text creditsText;

    //  public GameObjectResearch research;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startTurn()
    {
        isActive = true;
        uiPanel.text = playerColor.ToUpper() + " player's turn";
        creditsText.text = "Zucchinis : " + credits;
        credits += 10 + researchCredits;
        unitList = builder.listGrunt;
        foreach (UnitControlScript unit in unitList)
        {
            if (unit.owner == playerColor)
            {
                unit.remainingMoves = unit.maxMove;
                ownedUnits.Add(unit);
            }
        }
    }

    public void endTurn()
    {
        foreach (UnitControlScript unit in ownedUnits)
        {
            if (unit.bombTick <= 0)
                unit.getWrecked();
            else if (unit.isDetonating)
                unit.bombTick--;
        }
        ownedUnits.Clear();
        isActive = false;
    }

    public void EndTurnBtnClick()
    {
        if (isActive)
        {
            print(this.name + " ended turn");
            endTurn();
        }
        else
        {
            startTurn();
            print(this.name + " starting mine.");
        }
    }
}
