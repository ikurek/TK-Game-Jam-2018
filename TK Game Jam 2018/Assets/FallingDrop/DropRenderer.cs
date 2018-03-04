using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRenderer : MonoBehaviour {

    public GameObject drop;

    [Range(0f, 10f)]
    public float dropDelay = 3f;

	void Start () {
        StartCoroutine(InstanciateDrop());
	}

    IEnumerator InstanciateDrop(){
        while (true)
        {
            yield return new WaitForSeconds(dropDelay);
            Instantiate(drop, transform.position, Quaternion.identity);
        }
    }
}
