using UnityEngine;
using System.Collections.Generic;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    static void blastRadius(int power,Vector2 pos , HashSet<Vector2> radius)
    {
        radius.Add(pos);
        if (power == 0)
        {
            return;
        }

        Vector2 p = new Vector2(pos.x, pos.y);
        p.x = pos.x + 1;
        blastRadius(power - 1, p, radius);
        p.x = pos.x -1;
        blastRadius(power - 1, p, radius);
        p.x = pos.x;
        p.y = pos.y + 1;
        blastRadius(power - 1, p, radius);
        p.y = pos.y -1;
        blastRadius(power - 1, p, radius);
    }
}
