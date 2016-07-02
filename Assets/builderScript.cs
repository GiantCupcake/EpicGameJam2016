using UnityEngine;
using System.Collections.Generic;

public class builderScript : MonoBehaviour {
    public GameObject Chateau;
    public GameObject Grunt;
    GameObject GeneratorContent;
    Generatorrr mapGen;


    public Vector3 Chateau1Location;
    public Vector3 Chateau2Location;
    public Vector3 Grunt1Location;
    public Vector3 Grunt2Location;

    public int MapWidth;
    public int MapHeight;

    List<GameObject> listChateau = new List<GameObject>();
    List<GameObject> listGrunt = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GenerateMap();
        GenerateChateaux();
        GenerateGrunt();
	}

    // Update is called once per frame
    void Update()
    {

    }


    private void GenerateChateaux()
    {
        listChateau.Add((GameObject)Instantiate(Chateau, Chateau1Location, Quaternion.identity));
        listChateau.Add((GameObject)Instantiate(Chateau, Chateau2Location, Quaternion.identity));

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
