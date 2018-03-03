using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public bool grounded = true;
    public bool isRight = true;
    public float jumpPower = 20.0f;
    Vector2 velocity;


    void Update() {
        
        // Jumping
        if(Input.GetKey(KeyCode.Space) && grounded) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity.x, jumpPower));
        }

     }


    void FixedUpdate() {
        // Character Movement
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*moveSpeed, velocity.y);

        // Fliping sprites
        if(Input.GetAxis("Horizontal") > 0 && !isRight) {
            isRight = !isRight;
            flipCharacter(false);
            Debug.Log("Right");
        }
        if(Input.GetAxis("Horizontal") < 0 && isRight) {
            isRight = !isRight;
            flipCharacter(true);
            Debug.Log("Left");
        }

    }

    void flipCharacter(bool flip) {
        gameObject.GetComponent<SpriteRenderer>().flipX = flip;
    }

}
