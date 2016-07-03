using UnityEngine;
using System.Collections;

public class ExplosionFX : MonoBehaviour {
    AudioSource audio;
    ParticleSystem explPart;
    float ttl = 100f;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        explPart = GetComponent<ParticleSystem>();
        Explode();

	}
	
	// Update is called once per frame
	void Update () {
	    if (ttl <= 0)
        {
            Destroy(this.gameObject);
        }
        ttl--;
	}
    void Explode()
    {
        audio.Play();
        explPart.Emit(50);
    }
}
