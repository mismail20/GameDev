using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObject : MonoBehaviour
{

    public bool pressable;
    public KeyCode inputKey;

    public GameObject normalEffect, goodEffect, perfectEffect, missEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputKey)){
            if (pressable)
            {
                gameObject.SetActive(false);
                //Manager.GameManager.onHit();

                if(Mathf.Abs(transform.position.y) >= 0.25)
                {
                    Debug.Log("Normal");
                    Manager.GameManager.normalHit();
                    effectSpawner.instance.spawnHit(this.name);
                } else if (Mathf.Abs(transform.position.y) >= 0.05)
                {
                    Debug.Log("Good");
                    Manager.GameManager.goodHit();
                    effectSpawner.instance.spawnGood(this.name);
                }
                else
                {
                    Debug.Log("Perfect");
                    Manager.GameManager.pefectHit();
                    effectSpawner.instance.spawnPerfect(this.name);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
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
                Manager.GameManager.onMiss();
                effectSpawner.instance.spawnMiss(this.name);
            }
        }
    }
}
