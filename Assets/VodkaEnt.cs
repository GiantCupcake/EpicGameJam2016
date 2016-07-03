using UnityEngine;
using System.Collections;

public class VodkaEnt : MonoBehaviour {

    PlayerManagerGreen player1;
    PlayerManagerRed player2;
    public GameObject bottle;
    int LastPlayerActive;
    int PlayerActive;


    // Use this for initialization
    public virtual void Start()
    {
        player1 = FindObjectOfType<PlayerManagerGreen>();
        player2 = FindObjectOfType<PlayerManagerRed>();
        if (player1.isActive == true)
            LastPlayerActive = 2;
        if (player2.isActive == true)
            LastPlayerActive = 1;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (player1.isActive == true && LastPlayerActive == 2)
        {
            LastPlayerActive = 1;
            Instantiate(bottle, new Vector3(transform.position.x + Random.Range(1, 3), 0.5f, transform.position.z + Random.Range(1, 3)), Quaternion.identity);  
        }
        if (player2.isActive == true && LastPlayerActive == 1)
        {
            LastPlayerActive = 2;
            print("spawn");
        }
    }
}
