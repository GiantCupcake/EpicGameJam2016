using UnityEngine;
using System.Collections;

public class Generatorrr : MonoBehaviour {

    int startingX;
    int startingY;
    public GameObject CubeRause;
    public GameObject CubeBleu;
	// Use this for initialization

    const float offset = -0.5f;
	void Start () {
	}
	
	// Update is called once per frame+
	void Update () {
	
	}
    public void Generate(int width, int height)
    {
        int colorC = 0;
        for (int x=0; x<width; x++)
        {
            for (int y=0; y<height; y++)
            {
                Vector3 Loc = new Vector3(x, offset, y);
                if (colorC%2 == 0)
                {
                    Instantiate(CubeRause, Loc, Quaternion.identity);
                }
                else
                {
                    Instantiate(CubeBleu, Loc, Quaternion.identity);
                }

                colorC++;
            }
            colorC++;
        }
    }
}
