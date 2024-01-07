using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreWidget : MonoBehaviour
{
    [SerializeField] 
    Scorekeeper scorekeeper;

    TMP_Text text;

    void Start() 
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ((int) scorekeeper.score).ToString("N0");   
    }
}
