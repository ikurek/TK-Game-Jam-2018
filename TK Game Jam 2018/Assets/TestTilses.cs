using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTilses : MonoBehaviour {

	public Tilemap tileMap;
	
	// Use this for initialization
	void Start () {
		BoundsInt bounds = tileMap.cellBounds;
        TileBase[] allTiles = tileMap.GetTilesBlock(bounds);

		ScriptableObject.CreateInstance<TileSample>();


        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = allTiles[x + y * bounds.size.x];
				tile = ScriptableObject.CreateInstance<TileSample>();
                if (tile != null) {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                } else {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {


	}

}
