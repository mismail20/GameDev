using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateScript : MonoBehaviour

{

    public GameObject animationContainer;
    public Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textAnimator.Play("SlideUp"); // Plays the current animation
    }
}
