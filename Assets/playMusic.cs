using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    private float playSong = 120;
    private float timePassed = 0;
    private float loops = 0;
    private bool inMenu = false;
    public AudioSource Menu;
    public AudioSource Future;
    public AudioSource Samurai;
    public AudioSource BigCarTheft;
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
                        StartCoroutine(AudioFadeScript.FadeOut(Menu, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(Future, 8f));
                        // Menu.Stop();
                        // Future.Play();
                        break;
                    case 2:
                        StartCoroutine(AudioFadeScript.FadeOut(Future, 0.5f));
                        StartCoroutine(AudioFadeScript.FadeIn(Samurai, 5f));
                        // Future.Stop();
                        // Samurai.Play();
                        break;
                    case 3:
                        StartCoroutine(AudioFadeScript.FadeOut(Samurai, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(BigCarTheft, 8f));
                        // Samurai.Stop();
                        // BigCarTheft.Play();
                        break;
                    case 4:
                        StartCoroutine(AudioFadeScript.FadeOut(BigCarTheft, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(Menu, 8f));
                        // BigCarTheft.Stop();
                        // Menu.Play();
                        break;
                    case 5:
                        StartCoroutine(AudioFadeScript.FadeOut(Menu, 0.8f));
                        StartCoroutine(AudioFadeScript.FadeIn(BigCarTheft, 8f));
                        // Menu.Stop();
                        // Samurai.Play();
                        break;
                }
            }
        }
    }
}
