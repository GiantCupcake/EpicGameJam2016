using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

    private int layerMaskUnits;
    private int layerMaskTiles;
    public UnitControlScript selected;
    public Text textUnitName;
    public Text textUnitHp;
    public Text textUnitMove;
    public Text textUnitDamages;
    public Text textUnitTick;
    public Text textUnitIntox;
    public GameObject selectedPanel;
    public GameObject detonateButton;


    // Use this for initialization
    void Start () {
        selected = null;
        layerMaskUnits = 1 << 8;
        layerMaskTiles = 1 << 9;
	}
	
	// Update is called once per frame
	void Update () {
	
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

    void clearSelected()
    {
        detonateButton.SetActive(false);
        selectedPanel.SetActive(false);
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskUnits))
            {
                selected = hit.collider.gameObject.GetComponent<UnitControlScript>();
                writeSelected();
            }
            else
            {
                selected = null;
                clearSelected();
            }
        }
        if (Input.GetMouseButtonDown(1) && selected != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskTiles))
            {
                selected.moveTo(hit.transform.position.x, hit.transform.position.z);
                writeSelected();
            }
        }
    }
}
