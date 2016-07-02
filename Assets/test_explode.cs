using UnityEngine;
using System.Collections;

public class test_explode : MonoBehaviour {
    GameObject c_target_transform;
    Rigidbody c_target_rigidbody;
    ParticleSystem expl_fx;
	// Use this for initialization
	void Start () {
        c_target_transform = GameObject.Find("mesh");
        c_target_rigidbody = c_target_transform.GetComponent<Rigidbody>();
        expl_fx = GameObject.Find("explosion_emt").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.C))
        {
          //  c_target_rigidbody.AddForce(new Vector3(Random.RandomRange(90,100), ))
            expl_fx.Play();
            expl_fx.Stop();
        }
	}
}
