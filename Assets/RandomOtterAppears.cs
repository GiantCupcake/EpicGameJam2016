using UnityEngine;
using System.Collections;

public class RandomOtterAppears : MonoBehaviour {
    AudioSource criLoutreeeee;
    float inflateTime = 1f;
    float scale = 8f;
    bool isInflated = false;
    float spinCount = 1;
    float spinSpeed = 0.10f;

    float InitialDelay = 30f;
    float Delay = 0;
	// Use this for initialization
	void Start () {
        criLoutreeeee = GetComponent<AudioSource>();
        Delay = InitialDelay;
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0,1000) < 100.0f)
        {
            Debug.Log("Proc");
            if (isInflated == false)
            {
                StartCoroutine(Inflate());
            }
            if (isInflated == true)
            {
                StartCoroutine(Deflate());            
            }
        }
        Spin();
    }


    IEnumerator Inflate()
    {
        isInflated = true;
        float t = 0;
        while (t < 0.5f)
        {
            t += Time.deltaTime * (Time.timeScale / inflateTime);
            this.transform.localScale = new Vector3(this.transform.localScale.x + (t / scale), this.transform.localScale.y + (t / scale), this.transform.localScale.z + (t / scale));
            yield return 0;
        }
    }
    IEnumerator Deflate()
    {
        isInflated = false;
        float t = 0;
        while (t < 0.5f)
        {
            t += Time.deltaTime * (Time.timeScale / inflateTime);
            this.transform.localScale = new Vector3(this.transform.localScale.x - (t / scale), this.transform.localScale.y - (t / scale), this.transform.localScale.z - (t / scale));
            yield return 0;
        }
    }
    void Spin()
    {
        transform.Rotate(0, 0, 10);

    }
}
