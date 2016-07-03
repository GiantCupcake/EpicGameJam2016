using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	// Use this for initialization
    public int hp;
    public void Start () {
        GenerateHP();
	}

    // Update is called once per frame
    public void Update ()
    {
	}

    public void GenerateHP()
    {
        float RockHeight;
        hp = Random.Range(1, 5);
            RockHeight = hp * 0.28f;
        transform.localScale = new Vector3(transform.localScale.x, RockHeight, transform.localScale.z);
    }

    public void takeDmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            Destroy(gameObject);
    }
}
