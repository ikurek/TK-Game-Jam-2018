using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//*********************
//this script is checking is LevelManager has a instance and if not it will creat one 


public class Loader : MonoBehaviour
{
	public int levelCounter = 0;
	public Button buttonComponent;
	public GameObject levelManager ;

	private void Awake()
	{
		if (LevelManager.instance == null)
		{
			Instantiate(levelManager);
		}
		Debug.Log(" instancja sceny istnieje");
	}

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 100, 30), "Change to Level 1"))
		{
			Debug.Log("Scene1 loading: ");
			levelCounter++;
			SceneManager.LoadScene("Level" + levelCounter, LoadSceneMode.Additive);
		}
	}
}
