using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance = null; //its a singleton 
	public float levelStartDelay = 5f; //delay of restarting game from text screen



	private GameObject levelImage;
	private bool doingSetup; //prevent moving while on text screen

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		
		InitGame();
	}

	void InitGame()
	{
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
