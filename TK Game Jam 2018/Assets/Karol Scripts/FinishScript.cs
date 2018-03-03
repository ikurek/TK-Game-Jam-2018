using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
	public bool playerEntered = false;

	public float delayScene = 2;

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			playerEntered = true;
			Debug.Log("Triggered");
			CameraShaker.Instance.ShakeOnce(14f, 14f, 1f, 5f);
			StartCoroutine(LoadSceneAfterShake());
		}
	}

	IEnumerator LoadSceneAfterShake()
	{
		yield return new WaitForSeconds(delayScene);
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index);
	}
}
