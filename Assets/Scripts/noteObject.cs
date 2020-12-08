using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObject : MonoBehaviour
{

    public bool pressable;
    public KeyCode inputKey;

    public GameObject normalEffect, goodEffect, perfectEffect, missEffect;
    
    //Every note falling down is a noteObject

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
                Object.Destroy(gameObject, 0.2f); // we decide to destory the game object
                //Manager.GameManager.onHit();

                //The following hit detection was inspired by the Original GamesPlusJames script, although not exactly the same
                //as to work appropriately with the new effect generation.

                //The idea to use each postion as absolute was theirs, however we do our own thing with it.

                if (Mathf.Abs(transform.position.y) >= 0.25)
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

    //Credit to the idea of the collision system goes to the original GamesPlusJames script besides our edited spawner

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
                Object.Destroy(gameObject, 0.2f);
            }
        }
    }
}
