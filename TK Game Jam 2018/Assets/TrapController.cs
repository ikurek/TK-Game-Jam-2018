﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.collider.tag == "Player") {
			Debug.Log("Trapped");
		}
	}
}