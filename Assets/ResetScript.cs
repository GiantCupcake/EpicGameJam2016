using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void Reset()
    {
        Application.LoadLevel(0);
    }
}
