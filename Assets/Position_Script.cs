using UnityEngine;
using System.Collections;

public class Position_Script : MonoBehaviour {
    public float cameraSpeed;
    float zoomLevel = 1;
    float maxZoomLevel = 7;
    float zoomSpeed = 5f;

    float transitionDuration = 1.0f;

    //tempfloat
    Camera c_cam;
	// Use this for initialization
	void Start () {
        c_cam = GetComponent<Camera>();
	}
	// Update is called once per frame
    void Update()
    {
        CameraControl();
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(GoToLocation(new Vector3(0,this.transform.position.y,0)));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(GoToLocation(new Vector3(50, this.transform.position.y, 50)));
        }
    }
    void CameraControl()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(this.transform.position.x + (cameraSpeed/zoomLevel), this.transform.position.y, this.transform.position.z); 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(this.transform.position.x - (cameraSpeed/zoomLevel), this.transform.position.y, this.transform.position.z); 
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + (cameraSpeed / zoomLevel));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (cameraSpeed / zoomLevel));
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (zoomLevel < maxZoomLevel)
            {
                c_cam.orthographicSize-=zoomSpeed;
                zoomLevel++;
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (zoomLevel > 1)
            {
                c_cam.orthographicSize+=zoomSpeed;
                zoomLevel--;
            }
        }
    }
    IEnumerator GoToLocation(Vector3 target)
    {
        Vector3 startingPos = transform.position;
        float t = 0;
        while (t<1.0f)
        {
            t += Time.deltaTime * (Time.timeScale/transitionDuration);
            transform.position = Vector3.Lerp(startingPos, target, t);
            yield return 0;
        }

    }

}
