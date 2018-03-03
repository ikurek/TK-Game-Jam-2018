using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public bool grounded = true;
    public bool isRight = true;
    public float jumpPower = 20.0f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update() {
        
        // Jumping
        if(Input.GetKey(KeyCode.Space) && grounded) {
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            Debug.Log("jump");
        }

     }


    void FixedUpdate() {
        // Character Movement
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal")*moveSpeed, rb2d.velocity.y);

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
