using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float waveVelocity = 0.2f;
    public float initialWaveDimension = 0.01f;
    public float maxWaveDimension = 8;
    public float timeKeepVisible = 1f;

    private SpriteRenderer spr;
    private bool clap = false;

    [Space]

    public Sprite waveRed;
    public Sprite waveBlue;

    private void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.V))
        {
            resetWaveDimension();
            clap = true;   
        }
        if(Input.GetKey(KeyCode.C)){
            spr.sprite = waveRed;
        }
        if (Input.GetKey(KeyCode.V))
        {
            spr.sprite = waveBlue;
        }
        if(clap)SendClapWave(); 
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
        }else{
            transform.localScale += new Vector3(waveVelocity, waveVelocity, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("World"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(HideAfterTime(collision.gameObject));
        }
    }

    private IEnumerator HideAfterTime(GameObject gameObjectToHide)
    {
        yield return new WaitForSeconds(timeKeepVisible);
        gameObjectToHide.GetComponent<SpriteRenderer>().enabled = false;
    }
}
