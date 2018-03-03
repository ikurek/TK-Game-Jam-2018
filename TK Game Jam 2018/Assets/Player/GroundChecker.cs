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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "World") {
			playerController.grounded = true;
		}
    }

    void OnTriggerExit2D(Collider2D collider) {

        if(collider.tag == "World") {
		playerController.grounded = false;
		}
	}
}
