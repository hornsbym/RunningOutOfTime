
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LivesWidget : MonoBehaviour
{
    [SerializeField]
    private Image stopwatch;

    private List<GameObject> stopwatchImages;

    public Respawn respawn;
    int prevLives;

    void Start()
    {
        stopwatchImages = new List<GameObject>();
        prevLives = respawn.lives;
        SetLives();
    }

    void Update()
    {
        // Player has lost a life
        if (prevLives - respawn.lives != 0)
        {
            SetLives();
            prevLives = respawn.lives;
        }
    }

    void SetLives()
    {
        foreach (GameObject image in stopwatchImages)
        {
            Destroy(image);
        }

        for (int i = 0; i < respawn.lives; i++)
        {
            stopwatchImages.Add(Instantiate(stopwatch, transform).gameObject);
        }
    }
}
