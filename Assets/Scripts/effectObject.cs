using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectObject : MonoBehaviour
{

    public float lifelime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifelime);   //This is where we destroy the object
    }
}
