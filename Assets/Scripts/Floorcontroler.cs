using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorcontroler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FloorTile1, FloorTile2;


    // Update is called once per frame
    void FixedUpdate()
    {
        FloorTile1.transform.position -= new Vector3(GameManager.instance.wordScrollingSpeed, 0f, 0f);
    

        FloorTile2.transform.position -= new Vector3(GameManager.instance.wordScrollingSpeed, 0f, 0f);
        if (FloorTile2.transform.position.x < 0f)
        {
            FloorTile1.transform.position += new Vector3(32f, 0f, 0f);

            var temp = FloorTile1;
            FloorTile1 = FloorTile2;
            FloorTile2 = temp;
        }
    }
}
