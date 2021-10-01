using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Vector3 [] positions;

    void Start()
    {
        int randNum = Random.Range(0, positions.Length);
        transform.position = positions[randNum];

        Debug.Log(positions[randNum]);
    }
        
 
}


