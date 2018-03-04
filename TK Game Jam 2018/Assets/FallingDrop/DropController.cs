using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class DropController : MonoBehaviour {

    [SerializeField]
    [Range(0f, 10f)]
    private float decresedSpeed = 3f;
    [SerializeField]
    [Range(0f, 10f)]
    private float decresedSpeedTime = 4f;
    [Range(0f, 800f)]
    private float decresedJumpForce = 400f;

    private float originalSpeed = -1;
    private float originalJumpForce = -1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("Player") && collision.gameObject.GetComponent<PlatformerCharacter2D>().getMaxSpeed() != decresedSpeed && collision.gameObject.GetComponent<PlatformerCharacter2D>().getJumpForce() != decresedJumpForce)
        {
            PlatformerCharacter2D player = collision.gameObject.GetComponent<PlatformerCharacter2D>();
            if(originalSpeed == -1)originalSpeed = player.getMaxSpeed();
            if (originalJumpForce == -1)originalJumpForce = player.getJumpForce();
            player.setMaxSpeed(decresedSpeed);
            player.setJumpForce(decresedJumpForce);
            StartCoroutine(restoreVelocity(player));
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }else{
            Destroy(gameObject);
        }
    }

    IEnumerator restoreVelocity(PlatformerCharacter2D player){
        yield return new WaitForSeconds(decresedSpeedTime);
        player.setMaxSpeed(originalSpeed);
        player.setJumpForce(originalJumpForce);
        Destroy(gameObject);
    }
}
