using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float moveSpeed = 10.0f;
    public bool grounded = true;
    public float jumpPower = 2.0f;
    Vector2 velocity;


    void Update() {

        if(Input.GetKey(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity.x, jumpPower));
        }

     }


    void FixedUpdate() {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*moveSpeed, velocity.y);
    }

}
