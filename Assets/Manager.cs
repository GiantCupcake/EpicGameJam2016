using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    private int layerMaskUnits;
    private int layerMaskTiles;
    public UnitControlScript selected;

	// Use this for initialization
	void Start () {
        selected = null;
        layerMaskUnits = 1 << 8;
        layerMaskTiles = 1 << 9;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskUnits))
                selected = hit.collider.gameObject.GetComponent<UnitControlScript>();
            else
                selected = null;
        }
        if (selected != null)
        {

        }
        if (Input.GetMouseButtonDown(1) && selected != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskTiles))
            {
                selected.moveTo(hit.transform.position.x, hit.transform.position.z);
            }
        }


    }
    public void CheckPath(int power, int x, int y, HashSet<Vector2> radius)
    {
        int[,] RockMap = GetComponent<builderScript>().RockMap;
        if (RockMap[x, y] == 1 || power == 0)
            return;

        radius.Add(new Vector2(x, y));
        
        CheckPath(power - 1, x + 1, y, radius);
        CheckPath(power - 1, x - 1, y, radius);
        CheckPath(power - 1, x, y + 1, radius);
        CheckPath(power - 1, x, y - 1, radius);
    }
}
