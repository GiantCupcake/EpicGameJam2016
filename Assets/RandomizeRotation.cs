using UnityEngine;
using System.Collections;

public class RandomizeRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
