using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {
      Jump();


    }

    void Jump()
    {

      if (Input.GetButtonDown("Jump")){
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
      }
}
}
