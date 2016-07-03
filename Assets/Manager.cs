using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public GameObject SquareLight;
    public GameObject Grunt;
    private int layerMaskUnits;
    private int layerMaskTiles;
    private int layerMaskUi;
    public PlayerManager activePlayer;
    public GameObject realSelected;
    public UnitControlScript selected;
    public ChateauScript chateauSelected;
    public ChateauScript chateauRed;
    public ChateauScript chateauGreen;
    public Text textUnitName;
    public Text textUnitHp;
    public Text textUnitMove;
    public Text textUnitDamages;
    public Text textUnitTick;
    public Text textUnitIntox;
    public GameObject selectedPanel;
    public GameObject detonateButton;
    public GameObject castlePanel;
    public GameObject redCastleLifePanel;
    public GameObject greenCastleLifePanel;
    int[] coords = new int[2];
    List<Object> lights = new List<Object>();

    // Use this for initialization
    void Start () {
        selected = null;
        layerMaskUnits = 1 << 8;
        layerMaskTiles = 1 << 9;
        foreach (ChateauScript chateau in FindObjectsOfType<ChateauScript>())
        {
            if (chateau.owner == "red")
                chateauRed = chateau;
            else
                chateauGreen = chateau;
        }
	}

    void FixedUpdate()
    {
        redCastleLifePanel.GetComponentInChildren<Text>().text = chateauRed.hp + "/100";
//        redCastleLifePanel.transform.localScale = new Vector3(0.0f, (float)chateauRed.hp / 100, 0.0f);
        greenCastleLifePanel.GetComponent<Text>().text = chateauGreen.hp + "/100";
//        greenCastleLifePanel.transform.localScale = new Vector3(0.0f, (float)chateauGreen.hp / 100, 0.0f);
    }

    void writeSelected()
    {
        detonateButton.SetActive(true);
        selectedPanel.SetActive(true);
        textUnitName.text = selected.name;
        textUnitHp.text = "HP : " + selected.hp.ToString();
        textUnitMove.text = "Movements left : " + selected.remainingMoves.ToString();
        textUnitDamages.text = "Damages : " + selected.dmg.ToString();
        textUnitTick.text = "Turns to detonate : " + selected.bombTick.ToString();
        textUnitIntox.text = "Intoxication : " + selected.intox.ToString();
    }

    IEnumerator<WaitForSeconds> clearSelected()
    {
        yield return new WaitForSeconds(0.5f);
        ShutdownTiles();
        detonateButton.SetActive(false);
        selectedPanel.SetActive(false);
        castlePanel.SetActive(false);
        realSelected = null;
        chateauSelected = null;
        selected = null;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskUnits))
            {
                realSelected = hit.collider.gameObject;
                if (realSelected.GetComponent<UnitControlScript>() && realSelected.GetComponent<UnitControlScript>().owner == activePlayer.playerColor)
                {
                    selected = realSelected.GetComponent<UnitControlScript>();
                    writeSelected();
                    HilightTiles(selected.posX, selected.posY, selected.remainingMoves + 1);
                }
                else if (realSelected.GetComponent<ChateauScript>() && realSelected.GetComponent<ChateauScript>().owner == activePlayer.playerColor)
                {
                    chateauSelected = realSelected.GetComponent<ChateauScript>();
                    writeChateau();
                }
                else
                    StartCoroutine(clearSelected());
            }
            else if (Physics.Raycast(ray, out hit, 100.0f, layerMaskTiles)) {
                coords[0] = (int)hit.transform.position.x;
                coords[1] = (int)hit.transform.position.z;
                StartCoroutine(clearSelected());
            }
            else
                StartCoroutine(clearSelected());
        }
        if (Input.GetMouseButtonDown(1) && selected != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskTiles))
            {
                selected.moveTo((int)hit.transform.position.x, (int)hit.transform.position.z);
                writeSelected();
            }
        }


    }

    static public UnitControlScript MapContains(int x, int y)
    {
        foreach (UnitControlScript unit in FindObjectsOfType<UnitControlScript>())
        {
            if (unit.posX == x && unit.posY == y)
                return (unit);
        }
        return (null);
    }

    static public Obstacle MapContrainsObstacle(int x, int y)
    {
        foreach(Obstacle obstacle in FindObjectsOfType<Obstacle>())
        {
            if((int)obstacle.transform.position.x == x && (int)obstacle.transform.position.z == y)
            {
                return obstacle;
            }
        }
        return null;
    }

    static public ChateauScript MapContainsChateau(int x, int y)
    {
        foreach (ChateauScript chateau in FindObjectsOfType<ChateauScript>())
        {
            if ((int)chateau.transform.position.x == x && (int)chateau.transform.position.z == y)
            {
                return chateau;
            }
        }
        return null;
    }

    public void writeChateau()
    {
        castlePanel.SetActive(true);
    }

    public void HilightTiles(int x, int y,int radius)
    {
        HashSet<Vector2> cases = new HashSet<Vector2>();
        //remplit le Hash
        CheckPath(radius, x, y, cases);
        foreach(Vector2 v in cases)
        {
            //on créé un gameObject Highlight sur la map aux coordonoées v
            Vector3 location = new Vector3(v.x,0,v.y);
            lights.Add(Instantiate(SquareLight,location, new Quaternion()));
        }
    }

    public void ShutdownTiles()
    {
        foreach (Object light in lights)
        {
            Destroy(light);
        }
        lights.Clear();
    }

    public void CheckPath(int power, int x, int y, HashSet<Vector2> radius)
    {
        int[,] RockMap = FindObjectOfType<builderScript>().RockMap;

        if (RockMap[x, y] == 1 || power == 0)
            return;

        radius.Add(new Vector2(x, y));
        //TODO : executer ca si on sort pas de la map ----- Matt : j'ai fait mais je sais pas si c'est juste, je comprends pas trop le delire de la func ... CA MARCHE YO PS: vous etes cons
        if (x < FindObjectOfType<builderScript>().MapWidth - 1 && !radius.Contains(new Vector2(x+1,y)))
            CheckPath(power - 1, x + 1, y, radius);
        if (x > 0 && !radius.Contains(new Vector2(x - 1, y)))
            CheckPath(power - 1, x - 1, y, radius);
        if (y < FindObjectOfType<builderScript>().MapHeight - 1 && !radius.Contains(new Vector2(x, y+1)))
            CheckPath(power - 1, x, y + 1, radius);
        if (y > 0 && !radius.Contains(new Vector2(x, y-1)))
            CheckPath(power - 1, x, y - 1, radius);
    }

    public void DetonateBtnClick ()
    {
        selected.isDetonating = true;
    }

    IEnumerator<WaitUntil> WaitTilSpawnLoc(GameObject newUnit)
    {
        yield return new WaitUntil(() => coords[0] >= 0);
        GameObject unit = (GameObject)Instantiate(newUnit, new Vector3(coords[0], 0, coords[1]), Quaternion.identity);
        unit.GetComponent<UnitControlScript>().owner = activePlayer.playerColor;
        activePlayer.ownedUnits.Add(unit.GetComponent<UnitControlScript>());
        activePlayer.credits--;
        activePlayer.creditsText.text = "Zucchinis : " + activePlayer.credits;
    }


    public void spawnGrunt()
    {
        coords[0] = -1;
        coords[1] = -1;
        StartCoroutine(WaitTilSpawnLoc(Grunt));
    }
}
