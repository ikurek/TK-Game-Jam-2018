using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

	PlayerController playerController;

	void Start () {
		playerController = gameObject.GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.collider.tag == "World") {
			playerController.grounded = true;
		}
    }

	void OnCollisionExit2D(Collision2D collision) {

		if(collision.collider.tag == "World") {
		playerController.grounded = false;
		}
	}
}
