using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    // Use this for initialization
    void Start () {

        rb = this.GetComponent<Rigidbody2D>(); // Apply collision effects
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // Defining Screen Bounds

    }

    // Update is called once per frame
    void Update () {
      if(transform.position.x < screenBounds.x - 25){
            Destroy(this.gameObject); // Destroy object when off screen to prevent clutter of objects being created
        }

    }
}
