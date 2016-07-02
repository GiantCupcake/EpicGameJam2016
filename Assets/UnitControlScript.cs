using UnityEngine;
using System.Collections;

public abstract class UnitControlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public abstract void moveTo(float x, float y);
}
