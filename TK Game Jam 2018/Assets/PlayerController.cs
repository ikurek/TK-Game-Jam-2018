using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("World"))
        {
            Debug.Log("collide");
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
