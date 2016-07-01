using UnityEngine;
using System.Collections;

public class Position_Script : MonoBehaviour {
    public float cameraSpeed;
    float zoomLevel = 1;
    float maxZoomLevel = 5;
    float zoomSpeed = 5f;

    //tempfloat
    float deltaT;
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
            deltaT = 0f;
            GoToLocation(new Vector3(25,25,0));
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
    void GoToLocation(Vector3 target)
    {
        c_cam.transform.position = Vector3.Lerp(c_cam.transform.position, target,deltaT);
        deltaT += 0.2f;
    }

}
