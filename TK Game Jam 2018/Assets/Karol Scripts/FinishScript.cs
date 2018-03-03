using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
	public Loader sceneLoader = null;
	public bool playerEntered = false;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			playerEntered = true;
			Debug.Log("Triggered");
			int index = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene("Level" + index+1);
		}
	}
}
