using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerManager : MonoBehaviour
{

    public bool isActive;
    public string playerColor;
    public int credits;
    public int researchCredits;
    public Manager manager;
    public builderScript builder;
    public List<UnitControlScript> ownedUnits = new List<UnitControlScript>();
    List<UnitControlScript> mustDie = new List<UnitControlScript>();
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
        manager.activePlayer = this;
        uiPanel.text = playerColor.ToUpper() + " player's turn";
        credits += 10 + researchCredits;
        creditsText.text = "Zucchinis : " + credits;
        /*        unitList.AddRange(FindObjectsOfType<UnitControlScript>());
                foreach (UnitControlScript unit in unitList)
                {
                    if (unit.owner == playerColor)
                    {
                        unit.remainingMoves = unit.maxMove;
                        ownedUnits.Add(unit);
                    }
                }*/
    }


    public void endTurn()
    {
        bool someoneDies = true;

        while (someoneDies)
        {
            someoneDies = false;
            foreach (UnitControlScript unit in ownedUnits)
            {
                if (unit.bombTick <= 0 || unit.hp <= 0)
                {
                    mustDie.Add(unit);
                    someoneDies = true;
                }
                if (unit.isDetonating)
                    unit.bombTick--;
            }
            //        ownedUnits.Clear();
            foreach (UnitControlScript unit in mustDie)
            {
                ownedUnits.Remove(unit);
                unit.Assplosion();
            }
            mustDie.Clear();
        }
        isActive = false;
    }

    public void EndTurnBtnClick()
    {
        if (isActive)
            endTurn();
        else
            startTurn();
    }
}
