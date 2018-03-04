using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {
    public Texture2D fadeOutTexture;
    public Texture2D nextTexture;
    public float fadeSpeed = 0.0f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
    private AudioSource audio;

    void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    
    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        audio.Play();
        fadeDir = direction;
        return fadeSpeed;
    }

    private void OnLevelWasLoaded(int level)
    {
        
        BeginFade(-1);
    }
    
    
}
