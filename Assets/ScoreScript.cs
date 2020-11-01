using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        score.text = "Score = " + scoreValue;
        if(counter >= 1)
        {
            incrementScore();
        }
    }


    void incrementScore() 
    {
        scoreValue += 10;
        counter = 0;
    }

}
