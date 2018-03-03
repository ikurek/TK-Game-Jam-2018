using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTilses : MonoBehaviour {
	GameObject TileMap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		Destroy (TileMap);
	}
}
