using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    PlayerManagerGreen player1;
    PlayerManagerRed player2;
    int LastPlayerActive;
    int PlayerActive;


    // Use this for initialization
    public virtual void Start () {
        player1 = FindObjectOfType<PlayerManagerGreen>();
        player2 = FindObjectOfType<PlayerManagerRed>();
    }

    // Update is called once per frame
    public virtual void Update () {

        if (player1.isActive == true && LastPlayerActive == 2)
            print("spawn");
        if (player2.isActive == true && LastPlayerActive == 1)
            print("spawn");
    }
}
