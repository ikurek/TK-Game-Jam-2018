using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevelTrigger : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
            float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
            GameObject.Find("_GM").GetComponent<Fading>().fadeOutTexture = GameObject.Find("_GM").GetComponent<Fading>().nextTexture;
            StartCoroutine(LoadNextScene(fadeTime));
		}
	}

	IEnumerator LoadNextScene(float fadeTime)
	{
    yield return new WaitForSeconds(fadeTime);
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index + 1);
	}
}
