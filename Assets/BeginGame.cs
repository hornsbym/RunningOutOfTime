using Unity.VisualScripting;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    [SerializeField]
    Respawn player;
    [SerializeField]
    playMusic Music;

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            Music.inMenu = false;
            Music.Menu.Stop();
            // Music.BigCarTheft.Play();
            // StartCoroutine(AudioFadeScript.FadeOut(Music.Menu, 0.8f));
            StartCoroutine(AudioFadeScript.FadeIn(Music.BigCarTheft, 8f));
            player.Begin();
        }
    }
}
