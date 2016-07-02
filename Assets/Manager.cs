using UnityEngine;
using System.Collections;

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
        if (Input.GetMouseButtonDown(1) && selected != null)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMaskTiles))
            {
                if (hit.collider.gameObject != null)
                {
                    selected.moveTo(hit.transform.position.x, hit.transform.position.z);
                }
            }
        }
    }
}
