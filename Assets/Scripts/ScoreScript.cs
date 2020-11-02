using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    // intitalise the variables we need
    public static int scoreValue = 0;
    Text score;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> (); // Referencing the text component to a variable
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime; // Setting a counter to the current time

        score.text = "Score = " + scoreValue;
        if(counter >= 1) // Every second the score should be incremented
        {
            incrementScore();
        }
    }


    void incrementScore() 
    {
        scoreValue += 10; 
        counter = 0; // We need to reset the counter so it doesn't contiuously increment every frame after 10 seconds
    }

}
