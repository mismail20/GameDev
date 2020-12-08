using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    // Most of this script is the only script fully inspired by the GamesPlusJames tutorial. Most others are heavily modified by me.

    public bool gameStart;
    public float songTempo;


    // Start is called before the first frame update
    void Start()
    {
        songTempo = songTempo / 60f; //in order to get the tempo and speed of which they drop, we need to divide by 60. Song tempo is set
        //for each level.
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            transform.position -= new Vector3(0f, songTempo * Time.deltaTime, 0f); //Moves the pos of the arrowObjects
        }
    }
}
