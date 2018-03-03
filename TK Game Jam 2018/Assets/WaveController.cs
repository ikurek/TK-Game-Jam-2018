using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float waveVelocity = 0.2f;
    public float initialWaveDimension = 0.01f;
    public float maxWaveDimension = 8;
    public float waveDelay = 0.7f;

    [Space]

    public float delayFadeOut = 0.3f;
    public float velocityFadeOut = 0.1f;
    public float delayFadeIn = 0f;
    public float velocityFadeIn = 0.2f;
    public float waveFadeOutVelocity = 0.022f;

    private SpriteRenderer spr;
    private bool clap = false;

    [Space]

    public Sprite waveRed;
    public Sprite waveBlue;

    [Space]

    [Range(0f, 1f)]
    public float filterIntensity = 0.4f;
    public Sprite redFilter;
    public Sprite blueFilter;

    private static Dictionary<int, IEnumerator> hashMapCoroutineIn = new Dictionary<int, IEnumerator>();
    private static Dictionary<int, IEnumerator> hashMapCoroutineOut = new Dictionary<int, IEnumerator>();

	public AudioSource playerAudioSrc;

    private void Start()
    {
        spr = gameObject.GetComponent<SpriteRenderer>();
        spr.enabled = false;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.V))
        {
			playerAudioSrc.Play ();
            if(Input.GetKey(KeyCode.C))spr.sprite = waveRed;
            if (Input.GetKey(KeyCode.V)) spr.sprite = waveBlue;
            resetWaveDimension();
            clap = true;
            spr.enabled = true;
        }
		if (clap) {
			SendClapWave ();

		}

    }

    /*private IEnumerator ReenableWave()
    {
        yield return new WaitForSeconds(waveDelay);
        enableWave = true;
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gmo = collision.gameObject;
        if (gmo.tag.Equals("World") && clap)
        {

            if(spr.sprite == waveBlue) {
                if(collision.transform.parent.tag == "Blue") {
                    light(gmo);
                    //addColoredFilter(gmo, blueFilter);
                    StartCoroutine(ApplyFilter(gmo, Color.blue));
                }

            } else {
                if(collision.transform.parent.tag == "Red") {
                    light(gmo);
                    //addColoredFilter(gmo, redFilter);
                    StartCoroutine(ApplyFilter(gmo, Color.red));
                }
            }
        }
    }

    private void addColoredFilter(GameObject gmo, Color color){
        
    }

    IEnumerator ApplyFilter(GameObject gmo, Color color)
    {
        float timeToStart = Time.time;
        float filterCount = 0;
        while (filterCount < filterIntensity)
        {
            gmo.GetComponent<SpriteRenderer>().color = Color.Lerp(gmo.GetComponent<SpriteRenderer>().color, color, timeToStart);
            filterCount += 0.1f;
            yield return null;
        }
    }

    private void light(GameObject gmo) {
            IEnumerator toStop;
            hashMapCoroutineIn.TryGetValue(gmo.GetInstanceID(),out toStop);
            if(toStop != null)StopCoroutine(toStop);
            hashMapCoroutineIn.Remove(gmo.GetInstanceID());
            IEnumerator fadeInCoroutine = FadeInAfterTime(gmo);
            hashMapCoroutineIn.Add(gmo.GetInstanceID(),fadeInCoroutine);
            StartCoroutine(fadeInCoroutine);

            hashMapCoroutineOut.TryGetValue(gmo.GetInstanceID(), out toStop);
            if (toStop != null)StopCoroutine(toStop);
            hashMapCoroutineOut.Remove(gmo.GetInstanceID());
            IEnumerator fadeOutCoroutine = FadeOutAfterTime(gmo);
            hashMapCoroutineOut.Add(gmo.GetInstanceID(), fadeOutCoroutine);
            StartCoroutine(fadeOutCoroutine);
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
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1);
            spr.enabled = false;
        }else{
            transform.localScale += new Vector3(waveVelocity, waveVelocity, 0);
            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a - waveFadeOutVelocity);
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
        hashMapCoroutineOut.Remove(gameObjectToHide.GetInstanceID());
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
        hashMapCoroutineIn.Remove(gameObjectToHide.GetInstanceID());
    }
}
