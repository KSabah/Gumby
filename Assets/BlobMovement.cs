using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D body;

    void Start()
    {

    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        body.velocity = new Vector2(h * speed, v * speed);

    }
    
   
}
