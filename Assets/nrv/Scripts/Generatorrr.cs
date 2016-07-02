using UnityEngine;
using System.Collections;

public class Generatorrr : MonoBehaviour {

    int startingX;
    int startingY;
    public GameObject CubeRause;
    public GameObject CubeBleu;
    public int width;
    public int height;

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }
	// Use this for initialization
	void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Generate()
    {
        int colorC = 0;
        for (int x=0; x<width; x++)
        {
            for (int y=0; y<height; y++)
            {
                Vector3 Loc = new Vector3(x, 0, y);
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
