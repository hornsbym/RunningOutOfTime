
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

    void Start()
    {
        stopwatchImages = new List<GameObject>();
    }

    void Update()
    {
        SetLives();
    }

    void SetLives()
    {
        foreach(GameObject image in stopwatchImages) 
        {
            Destroy(image);
        }
        
        for (int i = 0; i < respawn.lives; i++)
        {
            stopwatchImages.Add(Instantiate(stopwatch, transform).gameObject);
        }
    }
}
