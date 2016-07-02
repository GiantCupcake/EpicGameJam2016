using UnityEngine;
using System.Collections;

public class Rolling : MonoBehaviour {
    public bool isRolling = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Space))
    {
        isRolling = !isRolling;
    }

        if (isRolling == true)
        {
            transform.RotateAroundLocal(new Vector3(-0.1f, 0, 0), 0.2f);
        }
        if (isRolling == false)
        {
            transform.rotation = Quaternion.EulerAngles(new Vector3(0.0f, 0.0f, 0.0f));
        }
	}
}
