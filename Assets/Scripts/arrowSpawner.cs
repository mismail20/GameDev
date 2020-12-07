using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawner : MonoBehaviour
{
    public GameObject leftArrow, rightArrow, upArrow, downArrow;
    public GameObject leftSpawner, rightSpawner, upSpawner, downSpawner;

    public static arrowSpawner instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn(float value)
    {
        if(value == 1)
        {
            var leftArrowObj = Instantiate(leftArrow, leftSpawner.transform.position, leftArrow.transform.rotation);
            leftArrowObj.transform.parent = GameObject.Find("ArrowContainer").transform;
        } 
        else if( value == 2)
        {
            var upArrowObj = Instantiate(upArrow, upSpawner.transform.position, upArrow.transform.rotation);
            upArrowObj.transform.parent = GameObject.Find("ArrowContainer").transform;
        } 
        else if (value == 3)
        {
            var downArrowObj = Instantiate(downArrow, downSpawner.transform.position, downArrow.transform.rotation);
            downArrowObj.transform.parent = GameObject.Find("ArrowContainer").transform;
        }
        else if (value == 4)
        {
            var rightArrowObj = Instantiate(rightArrow, rightSpawner.transform.position, rightArrow.transform.rotation);
            rightArrowObj.transform.parent = GameObject.Find("ArrowContainer").transform;
        } else if(value == 5)
        {

        }
    }
}
