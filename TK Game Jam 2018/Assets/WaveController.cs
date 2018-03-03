using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float waveVelocity = 0.2f;
    public float initialWaveDimension;
    public float maxWaveDimension = 8;

    private bool clap = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.C))clap = true;
        if(clap)SendClapWave(); 
    }

    private void SendClapWave(){
        if(transform.localScale.x > maxWaveDimension)
        {
            transform.localScale = new Vector3(initialWaveDimension, initialWaveDimension, transform.localScale.z);
            clap = false;
        }else{
            transform.localScale += new Vector3(waveVelocity, waveVelocity, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("World"))
        {
            Debug.Log("collide");
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
