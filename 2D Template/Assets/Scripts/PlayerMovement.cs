using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()

    {

        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);

    }

}
