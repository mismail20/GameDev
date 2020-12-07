using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectSpawner : MonoBehaviour
{

    public GameObject normalEffect, goodEffect, perfectEffect, missEffect, leftSpawner, rightSpawner, upSpawner, downSpawner;

    public static effectSpawner instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnHit(string name)
    {
        if(name.Contains("(Clone)"))
        {
            name = name.Substring(0, (name.Length - 7));
        }
       
        Debug.Log(name);
        if (name == "RightArrow")
        {
            Instantiate(normalEffect, rightSpawner.transform.position, normalEffect.transform.rotation);
        } else if(name == "LeftArrow"){
            Instantiate(normalEffect, leftSpawner.transform.position, normalEffect.transform.rotation);
        } else if(name == "UpArrow")
        {
            Instantiate(normalEffect, upSpawner.transform.position, normalEffect.transform.rotation);
        }
        else
        {
            Instantiate(normalEffect, downSpawner.transform.position, normalEffect.transform.rotation);
        }
        
    }

    public void spawnGood(string name)
    {
        if (name.Contains("(Clone)"))
        {
            name = name.Substring(0, (name.Length - 7));
        }

        Debug.Log(name);

        if (name == "RightArrow")
        {
            Instantiate(goodEffect, rightSpawner.transform.position, goodEffect.transform.rotation);
        } else if (name == "LeftArrow")
        {
            Instantiate(goodEffect, leftSpawner.transform.position, goodEffect.transform.rotation);
        }
        else if (name == "UpArrow")
        {
            Instantiate(goodEffect, upSpawner.transform.position, goodEffect.transform.rotation);
        } else
        {
            Instantiate(goodEffect, downSpawner.transform.position, goodEffect.transform.rotation);
        }
    }

    public void spawnPerfect(string name)
    {
        if (name.Contains("(Clone)"))
        {
            name = name.Substring(0, (name.Length - 7));
        }

        Debug.Log(name);
        if (name == "RightArrow")
        {
            Instantiate(perfectEffect, rightSpawner.transform.position, perfectEffect.transform.rotation);
        } else if(name == "LeftArrow")
        {
            Instantiate(perfectEffect, leftSpawner.transform.position, perfectEffect.transform.rotation);
        } else if(name == "UpArrow")
        {
            Instantiate(perfectEffect, upSpawner.transform.position, perfectEffect.transform.rotation);
        }else
        {
            Instantiate(perfectEffect, downSpawner.transform.position, perfectEffect.transform.rotation);
        }
    }

    public void spawnMiss(string name)
    {
        if (name.Contains("(Clone)"))
        {
            name = name.Substring(0, (name.Length - 7));
        }

        Debug.Log(name);
        if (name == "RightArrow")
        {
            Instantiate(missEffect, rightSpawner.transform.position, missEffect.transform.rotation);
        } else if(name == "LeftArrow")
        {
            Instantiate(missEffect, leftSpawner.transform.position, missEffect.transform.rotation);
        }
        else if (name == "UpArrow")
        {
            Instantiate(missEffect, upSpawner.transform.position, missEffect.transform.rotation);
        }
        else
        {
            Instantiate(missEffect, downSpawner.transform.position, missEffect.transform.rotation);
        }
    }
}
