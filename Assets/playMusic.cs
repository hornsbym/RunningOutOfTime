using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    
    private float playSong1 = 30;
    private float playSong2 = 60;
    private float playSong3 = 90;
    private float playSong4 = 120;
    private float playSong5 = 150;
    private float timePassed = 0;
    private bool inMenu = true;
    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inMenu == false){
            timePassed += Time.deltaTime;
            if (timePassed == playSong1)
            {
                // myAudioSource.clip()
                myAudioSource.Play();
            }
            else if (timePassed == playSong2)
            {
                myAudioSource.Play();
            }
            else if (timePassed == playSong3)
            {
                myAudioSource.Play();
            }
            else if (timePassed == playSong4)
            {
                myAudioSource.Play();
            }
        }
    }
}
