using Unity.VisualScripting;
using UnityEditor;
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
            Music.PostMenu();
            player.Begin();
        }
    }
}
