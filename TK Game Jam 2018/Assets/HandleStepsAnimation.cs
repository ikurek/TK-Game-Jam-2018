using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleStepsAnimation : MonoBehaviour {

	public StepsPlayer sp;
	public void PlaySound(){
		sp.PlayStepSound ();
	}
	public void SetIsInFirstSceneToFalse(){
		gameObject.GetComponent<Animator> ().SetBool("isFirstScene",false);
	}
}
