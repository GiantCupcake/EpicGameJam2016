using UnityEngine;
using System.Collections.Generic;

public class builderScript : MonoBehaviour {
    public GameObject Chateau;
    public GameObject Grunt;
    public GameObject VodkaEnt;
    public GameObject GoulagCorp;
    public GameObject NuclearCentral;
    public GameObject Rock;
    GameObject GeneratorContent;
    Generatorrr mapGen;

    public int MapWidth;
    public int MapHeight;
    public int RockDensity;
    public int[,] RockMap;

    Vector3 Chateau1Location;
    Vector3 Chateau2Location;
    public Vector3 Grunt1Location;
    public Vector3 Grunt2Location;

    List<GameObject> listChateau = new List<GameObject>();
    List<GameObject> listGrunt = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GenerateMap();
        GenerateChateaux();
        GenerateBuilding();
        GenerateRock();
        GenerateGrunt();
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateBuilding()
    {
        Instantiate(NuclearCentral, new Vector3(MapHeight / 2, 0, MapWidth / 2 + Random.Range(0, 5)), Quaternion.identity);
        Instantiate(VodkaEnt, new Vector3(MapHeight / 2, 0, MapWidth / 8), Quaternion.identity);
        Instantiate(GoulagCorp, new Vector3(MapHeight / 2, 0, MapWidth - MapWidth / 8), Quaternion.identity);
    }

    private void GenerateRock()
    {
        RockMap = new int[MapWidth, MapHeight];

        for (int x = 4; x < MapWidth / 2; x++)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                if (Random.Range(0, 1000) < RockDensity)
                {
                    RockMap[x, y] = 1;
                    RockMap[(MapWidth - x) - 1, (MapHeight - y) - 1] = 1;
                }
            }
        }
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < MapHeight / 2 - 4; y++)
            {
                if (Random.Range(0, 1000) < RockDensity)
                {
                    RockMap[x, y] = 1;
                    RockMap[(MapWidth - x) - 1, (MapHeight - y) - 1] = 1;
                }
            }
            for (int y = MapHeight / 2 + 4; y < MapHeight; y++)
            {
                if (Random.Range(0, 1000) < RockDensity)
                {
                    RockMap[x, y] = 1;
                    RockMap[(MapWidth - x) - 1, (MapHeight - y) - 1] = 1;
                }
            }
        }



        for (int x = 0; x < MapWidth; x++)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                if (RockMap[x, y] == 1)
                    Instantiate(Rock, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }

    private void GenerateChateaux()
    {
        Chateau1Location = new Vector3(0, 0, MapWidth / 2);
        Chateau2Location = new Vector3(MapHeight, 0, MapWidth / 2);

        listChateau.Add((GameObject)Instantiate(Chateau, new Vector3(0, 0, MapWidth / 2), Quaternion.identity));
        listChateau.Add((GameObject)Instantiate(Chateau, new Vector3(MapHeight, 0, MapWidth / 2), Quaternion.identity));

    }

    private void GenerateGrunt()
    {
        listGrunt.Add((GameObject)Instantiate(Grunt, Grunt1Location, Quaternion.identity));
        listGrunt.Add((GameObject)Instantiate(Grunt, Grunt2Location, Quaternion.identity));
    }
	

    //Start

    private void GenerateMap(){
        GeneratorContent = GameObject.Find("MapGeneratorrrrr");
        mapGen = GeneratorContent.GetComponent<Generatorrr>();
        mapGen.Generate(MapWidth, MapHeight);
    }

}
