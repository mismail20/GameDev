using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{

    public bool gameStart;
    public float songTempo;


    // Start is called before the first frame update
    void Start()
    {
        songTempo = songTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            transform.position -= new Vector3(0f, songTempo * Time.deltaTime, 0f);
        }
    }
}
