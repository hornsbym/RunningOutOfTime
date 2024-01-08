using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class AlienToEnglish : MonoBehaviour
{
    [SerializeField]
    string message;

    [SerializeField]
    [Tooltip("Seconds")]
    float conversionSpeed;

    [SerializeField]
    TMP_Text alien;

    [SerializeField]
    TMP_Text english;

    [SerializeField]
    [Tooltip("Seconds")]
    float initialDelay;

    void OnEnable()
    {
        alien.text = message;
        english.text = "";
        StartCoroutine(initiateConversion());
    }

    IEnumerator convertLetter()
    {
        yield return new WaitForSeconds(conversionSpeed);
        string currentMessage = alien.text;
        alien.text = currentMessage.Substring(1);
        english.text = english.text + currentMessage[0];
        if (alien.text.Length > 0)
        {
            StartCoroutine(convertLetter());
        }
    }

    IEnumerator initiateConversion()
    {
        yield return new WaitForSeconds(initialDelay);
        if (alien.text.Length > 0)
        {
            StartCoroutine(convertLetter());
        }
    }
}
