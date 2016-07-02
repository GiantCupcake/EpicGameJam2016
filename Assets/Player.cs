using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    List<Unit1ControlScript> listUnit = new List<Unit1ControlScript>();
    string name;
    int ID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Construct(string _name, int _ID)
    {
        name = _name;
        ID = _ID;
    }


}
