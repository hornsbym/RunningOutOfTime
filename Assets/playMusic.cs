using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    private float playSong = 90;
    private float timePassed = 0;
    public float loops = 2;
    public bool inMenu = true;
    public AudioSource Menu;
    public AudioSource Future;
    public AudioSource Samurai;
    public AudioSource Medieval;
    public AudioSource BigCarTheft;
    public AudioSource Void;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(inMenu == false){
            timePassed += Time.deltaTime;
            if (timePassed >= playSong)
            {
                timePassed = 0;
                loops += 1;
                switch(loops){
                    case 1:
                        StartCoroutine(AudioFadeScript.FadeOut(Void, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(Future, 8f));
                        break;
                    case 2:
                        StartCoroutine(AudioFadeScript.FadeOut(Future, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(BigCarTheft, 8f));
                        break;
                    case 3:
                        StartCoroutine(AudioFadeScript.FadeOut(BigCarTheft, 0.5f));
                        StartCoroutine(AudioFadeScript.FadeIn(Medieval, 5f));
                        break;
                    case 4:
                        StartCoroutine(AudioFadeScript.FadeOut(Medieval, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(Samurai, 8f));
                        break;
                    case 5:
                        StartCoroutine(AudioFadeScript.FadeOut(Samurai, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(Void, 8f));
                        break;
                }
            }
        }
    }
}
