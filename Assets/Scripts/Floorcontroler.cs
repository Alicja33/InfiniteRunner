using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floorcontroller : MonoBehaviour
{
    public GameObject floorTile1, floorTile2;
    public GameObject[] tiles;

    void FixedUpdate()
    {
        floorTile1.transform.position -= new Vector3(
            GameManager.instance.wordScrollingSpeed, 
            0f, 
            0f
        );
        floorTile2.transform.position -= new Vector3(
            GameManager.instance.wordScrollingSpeed, 
            0f, 
            0f
        );

        if (floorTile2.transform.position.x < 0f)
        {
            int index = Random.Range(0, tiles.Length);
            var newTile = Instantiate(
                tiles[index],
                floorTile2.transform.position + new Vector3(16f, 0f, 0f), 
                Quaternion.identity
            );

            Destroy(floorTile1);

            floorTile1 = floorTile2;
            floorTile2 = newTile;
        }
    }
}