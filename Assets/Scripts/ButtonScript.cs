using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    private SpriteRenderer SR;
    public Sprite defaultButton;
    public Sprite pressedButton;

    public KeyCode inputKey;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            SR.sprite = pressedButton;
        }

        if (Input.GetKeyUp(inputKey))
        {
            SR.sprite = defaultButton;
        }
    }
}
