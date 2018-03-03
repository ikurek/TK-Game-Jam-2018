using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float waveVelocity = 0.2f;
    public float initialWaveDimension = 0.01f;
    public float maxWaveDimension = 8;

    [Space]

    public float delayFadeOut = 0.3f;
    public float velocityFadeOut = 0.1f;
    public float delayFadeIn = 0f;
    public float velocityFadeIn = 0.2f;

    private SpriteRenderer spr;
    private bool clap = false;

    [Space]

    public Sprite waveRed;
    public Sprite waveBlue;

    private void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        spr.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.V))
        {
            if(Input.GetKey(KeyCode.C))spr.sprite = waveRed;
            if (Input.GetKey(KeyCode.V)) spr.sprite = waveBlue;
            resetWaveDimension();
            clap = true;
            spr.enabled = true;
        }
        if(clap)SendClapWave(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gmo = collision.gameObject;
        if (gmo.tag.Equals("World") && clap)
        {
            StartCoroutine(FadeInAfterTime(gmo));
            StartCoroutine(FadeOutAfterTime(gmo));
        }
    }

    private void resetWaveDimension()
    {
        transform.localScale = new Vector3(initialWaveDimension, initialWaveDimension, transform.localScale.z);
    }

    private void SendClapWave(){
        if(transform.localScale.x > maxWaveDimension)
        {
            resetWaveDimension();
            clap = false;
            spr.enabled = false;
        }else{
            transform.localScale += new Vector3(waveVelocity, waveVelocity, 0);
        }
    }

    private IEnumerator FadeOutAfterTime(GameObject gameObjectToHide)
    {
        yield return new WaitForSeconds(delayFadeOut);
        SpriteRenderer sprHide = gameObjectToHide.GetComponent<SpriteRenderer>();
        Color clr = sprHide.color;
        sprHide.color = new Color(clr.r, clr.g, clr.b, 1);
        while (sprHide.color.a > 0)
        {
            sprHide.color = new Color(clr.r, clr.g, clr.b, clr.a -= velocityFadeOut);
        }
    }

    private IEnumerator FadeInAfterTime(GameObject gameObjectToHide)
    {
        yield return new WaitForSeconds(delayFadeIn);
        SpriteRenderer sprHide = gameObjectToHide.GetComponent<SpriteRenderer>();
        Color clr = sprHide.color;
        sprHide.color = new Color(clr.r, clr.g, clr.b, 0);
        gameObjectToHide.GetComponent<SpriteRenderer>().enabled = true;
        while (sprHide.color.a < 1)
        {
            sprHide.color = new Color(clr.r, clr.g, clr.b, clr.a += velocityFadeIn);
        }
    }
}
