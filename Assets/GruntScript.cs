using UnityEngine;
using System.Collections;
using System;

public class GruntScript : UnitControlScript {

    public override void moveTo(float x, float y)
    {
        print("going to " + x + "---" + y);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
