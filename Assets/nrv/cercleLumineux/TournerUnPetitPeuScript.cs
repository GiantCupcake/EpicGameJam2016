using UnityEngine;
using System.Collections;

public class TournerUnPetitPeuScript : MonoBehaviour {
    float t = 0.0f;
    float Amplitude = 0.003f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Mathf.Sin(t) * Amplitude, this.transform.position.z);

        t+= 0.05f;
	}
}
