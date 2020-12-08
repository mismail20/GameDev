using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{

    //UNUSED SCRIPT

    public bool pressable;
    public KeyCode inputKey;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            if (pressable)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            pressable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeSelf)
        {
            if (collision.tag == "Activator")
            {
                pressable = false;
            }
        }
    }
}
