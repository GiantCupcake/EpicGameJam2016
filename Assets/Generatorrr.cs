using UnityEngine;
using System.Collections;

public class Generatorrr : MonoBehaviour {

    int startingX;
    int startingY;
    public GameObject CubeRause;
    public GameObject CubeBleu;
    public GameObject Arbre;
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

    public void GenerateOut(int width, int height)
    {
        for (int x=-4*width; x<width*4; x++)
        {
            for (int y = -4*height; y < height*4; y++)
            {
                Vector3 Loc = new Vector3(x, offset - 0.25f, y);
                Instantiate(CubeRause, Loc, Quaternion.identity);
            }
        }
    }

    public void GenerateTree(int width, int height, int offset)
    {
        for (int x = -offset; x<width+offset; x++)
        {
            for (int y= -offset; x<height+offset; x++)
            {
                if (x < 0 || x > width)
                {
                    if (y < 0 || y > width)
                    {
                        Vector3 Loc = new Vector3(x,-0.5f,y);
                        Instantiate(Arbre, Loc, Quaternion.identity);
                    }
                }
            }
        }
    }
}
